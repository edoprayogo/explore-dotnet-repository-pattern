using explore_pattern.Persistence.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace explore_pattern.Persistence.DependencyInjections
{
    public static class DatabaseContextExtensions
    {
        public static IServiceCollection AddDatabaseContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DemoStoreDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
