using Domain.Entities;

namespace Persistence.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        Task<bool> SaveChangesAsync();
    }
}
