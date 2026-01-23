using explore_pattern.Api.Databases;
using Microsoft.EntityFrameworkCore;

namespace explore_pattern.Api.Configurations.DependencyInjections
{
    public static class DatabaseContextExtensions
    {

        /// <summary>
        /// Registers database context and related services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">Application configuration.</param>
        /// <returns>The updated service collection.</returns>
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
