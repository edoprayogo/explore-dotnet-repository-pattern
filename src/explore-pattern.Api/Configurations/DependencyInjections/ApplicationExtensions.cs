using explore_pattern.Api.Interfaces.Persistences;
using explore_pattern.Api.Interfaces.Persistences.Repositories;
using explore_pattern.Api.Repositories;
using explore_pattern.Api.Services;
using explore_pattern.Api.UnitOfWorks;

namespace explore_pattern.Api.Configurations.DependencyInjections
{
    public static class ApplicationExtensions
    {

        /// <summary>
        /// Registers application layer (service, repository, etc.) dependencies.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ProductService>();
            return services;
        }
    }
}
