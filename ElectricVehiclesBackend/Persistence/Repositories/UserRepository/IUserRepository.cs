using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        Task<bool> SaveChangesAsync();
    }
}
