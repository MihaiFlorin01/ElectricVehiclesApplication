namespace Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : BaseEntityModel;

        Task<bool> SaveChangesAsync();
    }
}
