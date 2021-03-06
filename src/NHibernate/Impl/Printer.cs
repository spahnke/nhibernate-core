using System.Collections.Generic;
using System.Linq;
using NHibernate.Engine;
using NHibernate.Intercept;
using NHibernate.Metadata;
using NHibernate.Properties;
using NHibernate.Type;
using NHibernate.Util;

namespace NHibernate.Impl
{
	public sealed class Printer
	{
		private readonly ISessionFactoryImplementor _factory;
		private static readonly INHibernateLogger log = NHibernateLogger.For(typeof(Printer));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity">an actual entity object, not a proxy!</param>
		/// <returns></returns>
		public string ToString(object entity)
		{
			IClassMetadata cm = _factory.GetClassMetadata(entity.GetType());
			if (cm == null)
			{
				return entity.GetType().FullName;
			}

			IDictionary<string, string> result = new Dictionary<string, string>();

			if (cm.HasIdentifierProperty)
			{
				result[cm.IdentifierPropertyName] =
					cm.IdentifierType.ToLoggableString(cm.GetIdentifier(entity), _factory);
			}

			IType[] types = cm.PropertyTypes;
			string[] names = cm.PropertyNames;
			object[] values = cm.GetPropertyValues(entity);

			for (int i = 0; i < types.Length; i++)
			{
				var value = values[i];
				if (Equals(LazyPropertyInitializer.UnfetchedProperty, value) || Equals(BackrefPropertyAccessor.Unknown, value))
				{
					result[names[i]] = value.ToString();
				}
				else
				{
					result[names[i]] = types[i].ToLoggableString(value, _factory);
				}
			}

			return cm.EntityName + CollectionPrinter.ToString(result);
		}

		public string ToString(IType[] types, object[] values)
		{
			List<string> list = new List<string>(types.Length);

			for (int i = 0; i < types.Length; i++)
			{
				if (types[i] != null)
				{
					list.Add(types[i].ToLoggableString(values[i], _factory));
				}
			}
			return CollectionPrinter.ToString(list);
		}

		public string ToString(IDictionary<string, TypedValue> namedTypedValues)
		{
			IDictionary<string, string> result = new Dictionary<string, string>(namedTypedValues.Count);

			foreach (KeyValuePair<string, TypedValue> me in namedTypedValues)
			{
				TypedValue tv = me.Value;
				result[me.Key] = tv.Type.ToLoggableString(tv.Value, _factory);
			}

			return CollectionPrinter.ToString(result);
		}

		internal string ToString(IEnumerable<KeyValuePair<string, TypedValue>> namedTypedValues)
		{
			return CollectionPrinter.ToString(
				namedTypedValues.Select(
					ntv => new KeyValuePair<string, string>(
						ntv.Key,
						ntv.Value.Type.ToLoggableString(ntv.Value.Value, _factory))));
		}

		public void ToString(object[] entities)
		{
			if (!log.IsDebugEnabled() || entities.Length == 0)
			{
				return;
			}

			log.Debug("listing entities:");
			var i = 0;

			foreach(var entity in entities)
			{
				if (i++ > 20)
				{
					log.Debug("more......");
					break;
				}
				log.Debug(ToString(entity));
			}
		}

		public Printer(ISessionFactoryImplementor factory)
		{
			_factory = factory;
		}
	}
}
