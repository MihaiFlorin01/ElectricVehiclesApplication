using Persistence.Repositories.BikeRepositories;

namespace API.Extensions
{
    public static class ServiceExtension
    {
        public static void MethodExtension(IServiceCollection services)
        {
            services.AddScoped<IBikeRepository, BikeRepository>();
        }
    }
}
