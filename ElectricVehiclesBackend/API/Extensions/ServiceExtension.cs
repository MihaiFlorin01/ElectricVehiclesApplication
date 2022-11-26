using Persistence.Repositories.BikeRepositories;
using Persistence.Repositories.UserRepository;

namespace API.Extensions
{
    public static class ServiceExtension
    {
        public static void MethodExtension(IServiceCollection services)
        {
            services.AddScoped<IBikeRepository, BikeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
