using Persistence.Repositories.BikeRepositories;
using Persistence.Repositories.BikeTypeRepository;
using Persistence.Repositories.CustomerRepositories;
using Persistence.Repositories.UserRepository;

namespace API.Extensions
{
    public static class ServiceExtension
    {
        public static void MethodExtension(IServiceCollection services)
        {
            services.AddScoped<IBikeRepository, BikeRepository>();
            services.AddScoped<IBikeTypeRepository, BikeTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
