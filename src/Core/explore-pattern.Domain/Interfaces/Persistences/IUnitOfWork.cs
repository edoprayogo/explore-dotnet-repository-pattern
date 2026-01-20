using explore_pattern.Domain.Entities;

namespace explore_pattern.Domain.Interfaces.Persistences
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Store> Stores { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Order> Orders { get; }

        Task<int> SaveChangesAsync();
    }
}
