using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Create and persist an entity in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns>The entity's id</returns>
        string Create(T entity, string id);

        /// <summary>
        /// Asynchronously create and persist an entity in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns>The entity's id</returns>
        Task<string> CreateAsync(T entity, string id);

        /// <summary>
        /// Get an entity from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The entity</returns>
        T Read(string id);

        /// <summary>
        /// Asynchronously get an entity from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> ReadAsync(string id);

        /// <summary>
        /// Update an entity in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        void Update(T entity, string id);

        /// <summary>
        /// Asynchronously update an entity in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity, string id);

        /// <summary>
        /// Delete an entity from database
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// Asynchronously delete an entity from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}

