using System.Threading.Tasks;

namespace DAL.Repositories
{
    // Use AutoMapper to shift from T class (which is supposed to be a DTO) to a U class which is the Model entity and reverse.
    // Google "Repository and Unit Of Work Pattern" to use repositories at their maximum power
    // https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implemenation-entity-framework-core
    public class RepositoryBase<T, U> : IRepository<T, U>
    {
        public virtual string Create(T entity, string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<string> CreateAsync(T entity, string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual T Read(string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<T> ReadAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(T entity, string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task UpdateAsync(T entity, string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}