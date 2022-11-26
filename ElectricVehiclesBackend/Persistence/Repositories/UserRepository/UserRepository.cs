using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext? _databaseContext;

        public UserRepository(DatabaseContext? databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _databaseContext?.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _databaseContext?.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void AddUser(User user)
        {
            _databaseContext?.Add(user);
        }

        public void UpdateUser(User user)
        {
            _databaseContext?.Update(user);
        }

        public void DeleteUser(User user)
        {
            _databaseContext?.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _databaseContext?.SaveChangesAsync() > 0;
        }
    }
}
