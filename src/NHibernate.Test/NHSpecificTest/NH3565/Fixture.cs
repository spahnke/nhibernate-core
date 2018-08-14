using System.Linq;
using NHibernate.Linq;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH3565
{
	[TestFixture]
	public class Fixture : BugTestCase
	{
		protected override void OnSetUp()
		{
			using (var session = OpenSession())
			using (var transaction = session.BeginTransaction())
			{
				var e1 = new Entity { Name = "Bob" };
				session.Save(e1);

				var e2 = new Entity { Name = "Sally" };
				session.Save(e2);

				session.Flush();
				transaction.Commit();
			}
		}

		protected override void OnTearDown()
		{
			using (var session = OpenSession())
			using (var transaction = session.BeginTransaction())
			{
				session.Delete("from System.Object");

				session.Flush();
				transaction.Commit();
			}
		}

		[Test]
		//[Ignore("Does not reproduce the issue and is incorrectly named?!")]
		public void YourTestName()
		{
			using (var session = OpenSession())
			using (session.BeginTransaction())
			{
				var entities = (from e in session.Query<Entity>()
								where e.Name == "Bob"
								select e).ToList();

				entities = (from e in session.Query<Entity>()
								//where e.Name.StartsWith(e.Name.Substring(0, 1) + "o")
							where e.Name.StartsWith("b")
							select e).ToList();

				Assert.AreEqual(1, entities.Count);
			}
		}
	}
}
