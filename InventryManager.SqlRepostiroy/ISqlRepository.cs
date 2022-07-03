using System.Linq.Expressions;

namespace InventryManager.SqlRepostiroy
{
    public interface ISqlRepository<T> where T : class
    {
        /// <summary>
        /// Get all queries
        /// </summary>
        /// <returns>IQueryable queries</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Remove entity from database
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Remove entity from database
        /// </summary>
        /// <param name="keys">entity keys</param>
        void Delete(params object[] keys);

        /// <summary>
        /// Edit entity
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Persists all updates to the data source.
        /// </summary>
        void SaveChanges();
        Task SaveChangesAsync();
    }
}