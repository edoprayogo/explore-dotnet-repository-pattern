using explore_pattern.Api.Databases;
using explore_pattern.Api.Interfaces.Persistences.Repositories;
using explore_pattern.Api.Models.Dtos.Models;
using Microsoft.EntityFrameworkCore;

namespace explore_pattern.Api.Repositories
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
