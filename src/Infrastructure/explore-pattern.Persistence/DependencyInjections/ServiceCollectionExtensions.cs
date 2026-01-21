using explore_pattern.Application.Services;
using explore_pattern.Domain.Interfaces.Persistences;
using explore_pattern.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace explore_pattern.Persistence.DependencyInjections
{
    /// <summary>
    /// Provides extension methods for registering infrastructure-related services
    /// into the dependency injection container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all infrastructure and application dependencies.
        /// This method should be called from Program.cs.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">Application configuration.</param>
        /// <returns>The updated service collection.</returns
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
    

            // Register database-related dependencies
            services.AddDatabaseContext(configuration);


            // Register application layer (service, repository, etc.) dependencies
            services.AddApplication();


            return services;
        }

    }
}
