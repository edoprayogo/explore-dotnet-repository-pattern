using explore_pattern.Domain.Dtos.Models;
using explore_pattern.Domain.Entities;
using explore_pattern.Domain.Interfaces.Persistences.Repositories;
using explore_pattern.Persistence.Databases;
using Microsoft.EntityFrameworkCore;

namespace explore_pattern.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoStoreDbContext _context;

        public ProductRepository(DemoStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDescListDto>> GetProductDescList()
        {
            return await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                    .ThenInclude(c => c.Store)
                .Select(p => new ProductDescListDto
                {
                    Id = p.Id,
                    ProductName = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    StoreName = p.Category.Store.Name
                })
                .ToListAsync();
        }
    }

}
