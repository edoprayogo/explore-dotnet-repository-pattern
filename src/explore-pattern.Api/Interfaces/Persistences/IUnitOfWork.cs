using explore_pattern.Api.Interfaces.Persistences.Repositories;
using explore_pattern.Api.Models.Entities;

namespace explore_pattern.Api.Interfaces.Persistences
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Store> Stores { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Order> Orders { get; }

        IProductRepository ProductQueries { get; }

        Task<int> SaveChangesAsync();
    }
}
