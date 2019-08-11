using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RepositoryBase<T> : IRepository<T>
    {
        public string Create(T entity, string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> CreateAsync(T entity, string id)
        {
            throw new System.NotImplementedException();
        }

        public T Read(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> ReadAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity, string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(T entity, string id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
