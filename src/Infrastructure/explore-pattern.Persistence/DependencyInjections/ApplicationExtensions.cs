using explore_pattern.Application.Commands.Stores.CreateStore;
using explore_pattern.Application.Queries.Stores.GetStoreById;
using explore_pattern.Application.Queries.Stores.GetStoreList;
using explore_pattern.Application.Services;
using explore_pattern.Domain.Interfaces.Persistences;
using explore_pattern.Domain.Interfaces.Persistences.Repositories;
using explore_pattern.Persistence.Repositories;
using explore_pattern.Persistence.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace explore_pattern.Persistence.DependencyInjections
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
            services.AddScoped<IStoreReadRepository, StoreReadRepository>();
            services.AddScoped<IStoreWriteRepository, StoreWriteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ProductService>();

            services.AddScoped<GetStoreListHandler>();
            services.AddScoped<GetStoreByIdHandler>();
            services.AddScoped<CreateStoreHandler>();

            return services;
        }
    }
}
