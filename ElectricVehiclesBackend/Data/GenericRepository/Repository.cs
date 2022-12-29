using Abstractions;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : BaseEntityModel
    {
        private readonly DbSet<T> _dbSet;

        public Repository(DatabaseContext databaseContext)
        {
            _dbSet = databaseContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }
        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsDeleted = true;

            return _dbSet.Update(entity) is not null;
        }

    }
}
