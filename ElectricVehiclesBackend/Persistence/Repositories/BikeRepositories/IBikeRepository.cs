using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.BikeRepositories
{
    public interface IBikeRepository
    {
        Task<IEnumerable<Bike>> GetBikesAsync();

        Task<Bike> GetBikeByIdAsync(int id);
        
        void AddBike(Bike bike);
        
        void UpdateBike(Bike bike);
        
        void DeleteBike(int id);
        
        Task<bool> SaveChangesAsync();
    }
}
