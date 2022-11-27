using Domain.Entities;

namespace Persistence.Repositories.BikeTypeRepository
{
    public interface IBikeTypeRepository
    {
        Task<IEnumerable<BikeType>> GetBikeTypesAsync();

        Task<BikeType> GetBikeTypeByIdAsync(int id);

        void AddBikeType(BikeType bikeType);

        void UpdateBikeType(BikeType bikeType);

        void DeleteBikeType(BikeType bikeType);

        Task<bool> SaveChangesAsync();
    }
}
