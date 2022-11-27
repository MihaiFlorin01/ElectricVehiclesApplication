using Infrastructure.Abstractions;

namespace Persistence.Abstractions
{
    public interface IRepository<T> where T : BaseEntityModel
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(long id);

        T Add(T entity);

        T Update(T entity);

        Task<bool> DeleteByIdAsync(long id);
    }
}