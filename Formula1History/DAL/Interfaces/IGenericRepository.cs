using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    /// <summary>
    /// Generic repository for any type of entity
    /// </summary>
    /// <typeparam name="T">any entity type</typeparam>
    public interface IGenericRepository<T>
        where T : class
    {
        /// <summary>
        /// Get queryable type
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Query();

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">entity id</param>
        T Get(Guid id);

        /// <summary>
        /// Get entity by id asynchronously
        /// </summary>
        /// <param name="id">entity id</param>
        Task<T> GetAsync(Guid id);

        /// <summary>
        /// Get all entities
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get all entities asynchronously
        /// </summary>
        IAsyncEnumerable<T> GetAllAsync();

        /// <summary>
        /// Search entities inside database 
        /// </summary>
        /// <param name="predicate"></param>
        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Search entities inside database asynchronously
        /// </summary>
        /// <param name="predicate"></param>
        IAsyncEnumerable<T> FilterAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Create new entity
        /// </summary>
        /// <param name="entity">new entity that doesn't exist in database</param>
        void Create(T entity);

        /// <summary>
        /// Create new entity asynchronously
        /// </summary>
        /// <param name="entity">new entity that doesn't exist in database</param>
        Task CreateAsync(T entity);

        /// <summary>
        /// Update existing entity
        /// </summary>
        /// <param name="entity">existing entity</param>
        void Update(T entity);

        /// <summary>
        /// Remove entity entirely
        /// </summary>
        /// <param name="entity">entity to remove</param>
        void Delete(T entity);

        /// <summary>
        /// Save entity entirely
        /// </summary>
        void Save();

        /// <summary>
        /// Async save  entity entirely
        /// </summary>
        Task SaveAsync();
    }
}