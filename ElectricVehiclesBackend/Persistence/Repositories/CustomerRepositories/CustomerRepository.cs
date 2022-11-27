using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CustomerRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _databaseContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _databaseContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            _databaseContext.Add(customer);
        }

        public void UpdateCustomer(Customer customer) 
        {
            _databaseContext.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _databaseContext.Remove(customer);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync() > 0;
        }
    }
}
