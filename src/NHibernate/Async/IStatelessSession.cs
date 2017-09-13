﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Engine;

namespace NHibernate
{
	using System.Threading.Tasks;
	using System.Threading;
	/// <content>
	/// Contains generated async methods
	/// </content>
	public partial interface IStatelessSession : IDisposable
	{

		/// <summary>Insert an entity.</summary>
		/// <param name="entity">A new transient instance</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <returns>The identifier of the instance</returns>
		Task<object> InsertAsync(object entity, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>Insert a row.</summary>
		/// <param name="entityName">The name of the entity to be inserted</param>
		/// <param name="entity">A new transient instance</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <returns>The identifier of the instance</returns>
		Task<object> InsertAsync(string entityName, object entity, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>Update an entity.</summary>
		/// <param name="entity">A detached entity instance</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		Task UpdateAsync(object entity, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>Update an entity.</summary>
		/// <param name="entityName">The name of the entity to be updated</param>
		/// <param name="entity">A detached entity instance</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		Task UpdateAsync(string entityName, object entity, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>Delete an entity.</summary>
		/// <param name="entity">A detached entity instance</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		Task DeleteAsync(object entity, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>Delete an entity.</summary>
		/// <param name="entityName">The name of the entity to be deleted</param>
		/// <param name="entity">A detached entity instance</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		Task DeleteAsync(string entityName, object entity, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>Retrieve a entity.</summary>
		/// <returns>A detached entity instance</returns>
		Task<object> GetAsync(string entityName, object id, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Retrieve an entity.
		/// </summary>
		/// <returns>A detached entity instance</returns>
		Task<T> GetAsync<T>(object id, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Retrieve an entity, obtaining the specified lock mode.
		/// </summary>
		/// <returns>A detached entity instance</returns>
		Task<object> GetAsync(string entityName, object id, LockMode lockMode, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Retrieve an entity, obtaining the specified lock mode.
		/// </summary>
		/// <returns>A detached entity instance</returns>
		Task<T> GetAsync<T>(object id, LockMode lockMode, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Refresh the entity instance state from the database.
		/// </summary>
		/// <param name="entity">The entity to be refreshed.</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		Task RefreshAsync(object entity, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Refresh the entity instance state from the database.
		/// </summary>
		/// <param name="entityName">The name of the entity to be refreshed.</param>
		/// <param name="entity">The entity to be refreshed.</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		Task RefreshAsync(string entityName, object entity, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Refresh the entity instance state from the database.
		/// </summary>
		/// <param name="entity">The entity to be refreshed.</param>
		/// <param name="lockMode">The LockMode to be applied.</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		Task RefreshAsync(object entity, LockMode lockMode, CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Refresh the entity instance state from the database.
		/// </summary>
		/// <param name="entityName">The name of the entity to be refreshed.</param>
		/// <param name="entity">The entity to be refreshed.</param>
		/// <param name="lockMode">The LockMode to be applied.</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		Task RefreshAsync(string entityName, object entity, LockMode lockMode, CancellationToken cancellationToken = default(CancellationToken));
	}
}
