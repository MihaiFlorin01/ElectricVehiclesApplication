using Domain.Entities;

namespace Infrastructure.Repositories.BikeRepositories
{
    public interface IBikeRepository
    {
        Task<IEnumerable<Bike>> GetBikesAsync();

        Task<Bike> GetBikeByIdAsync(int id);
        
        void AddBike(Bike bike);
        
        void UpdateBike(Bike bike);
        
        void DeleteBike(Bike bike);
        
        Task<bool> SaveChangesAsync();
    }
}
