using explore_pattern.Api.Databases;
using explore_pattern.Api.Interfaces.Persistences;
using explore_pattern.Api.Interfaces.Persistences.Repositories;
using explore_pattern.Api.Models.Entities;
using explore_pattern.Api.Repositories;

namespace explore_pattern.Api.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DemoStoreDbContext _context;

        public IGenericRepository<Store> Stores { get; }
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Order> Orders { get; }

        public IProductRepository ProductQueries { get; }

        public UnitOfWork(DemoStoreDbContext context)
        {
            _context = context;

            Stores = new GenericRepository<Store>(context);
            Categories = new GenericRepository<Category>(context);
            Products = new GenericRepository<Product>(context);
            Orders = new GenericRepository<Order>(context);
            ProductQueries = new ProductRepository(context);
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
            => _context.Dispose();
    }
}
