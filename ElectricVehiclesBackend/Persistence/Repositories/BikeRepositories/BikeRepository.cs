using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.BikeRepositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly DatabaseContext? _databaseContext;

        public BikeRepository(DatabaseContext? databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Bike>> GetBikesAsync()
        {
            return await _databaseContext?.Bikes.ToListAsync();
        }

        public async Task<Bike> GetBikeByIdAsync(int id)
        {
            return await _databaseContext?.Bikes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void AddBike(Bike bike)
        {
            _databaseContext?.Add(bike);
        }

        public void UpdateBike(Bike bike)
        {
            _databaseContext?.Update(bike);
        }

        public void DeleteBike(int id)
        {
            var bike = GetBikeByIdAsync(id).Result;
            _databaseContext?.Remove(bike);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _databaseContext?.SaveChangesAsync() > 0;
        }
    }
}
