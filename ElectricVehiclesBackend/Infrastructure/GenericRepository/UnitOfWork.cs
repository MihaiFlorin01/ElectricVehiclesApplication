using Abstractions;
using Data.Context;

namespace Data.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntityModel
        {
            return new Repository<T>(_databaseContext);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync() > 0;
        }
    }
}
