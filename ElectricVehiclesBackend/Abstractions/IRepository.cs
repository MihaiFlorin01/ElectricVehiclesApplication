namespace Abstractions
{
    public interface IRepository<T> where T : BaseEntityModel
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        T Add(T entity);

        T Update(T entity);

        Task<bool> DeleteByIdAsync(int id);
    }
}