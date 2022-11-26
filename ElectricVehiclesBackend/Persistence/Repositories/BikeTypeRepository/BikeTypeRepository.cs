using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.BikeTypeRepository
{
    public class BikeTypeRepository : IBikeTypeRepository
    {
        private readonly DatabaseContext? _databaseContext;

        public BikeTypeRepository(DatabaseContext? databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public async Task<IEnumerable<BikeType>> GetBikeTypesAsync()
        {
            return await _databaseContext?.BikeTypes.ToListAsync();
        }

        public async Task<BikeType> GetBikeTypeByIdAsync(int id)
        {
            return await _databaseContext?.BikeTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void AddBikeType(BikeType bikeType)
        {
            _databaseContext?.Add(bikeType);
        }

        public void UpdateBikeType(BikeType bikeType)
        {
            _databaseContext?.Update(bikeType);
        }

        public void DeleteBikeType(BikeType bikeType)
        {
            _databaseContext?.Remove(bikeType);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _databaseContext?.SaveChangesAsync() > 0;
        }
    }
}
