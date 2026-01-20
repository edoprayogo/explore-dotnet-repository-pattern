using explore_pattern.Domain.Entities;
using explore_pattern.Domain.Interfaces.Persistences;

namespace explore_pattern.Application.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // READ ALL
        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _uow.Products.GetAllAsync();

        // READ BY ID
        public async Task<Product?> GetByIdAsync(Guid id)
            => await _uow.Products.GetByIdAsync(id);

        // CREATE
        public async Task<Guid> CreateAsync(Guid categoryId, string name, decimal price)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                CategoryId = categoryId,
                Name = name,
                Price = price
            };

            await _uow.Products.AddAsync(product);
            await _uow.SaveChangesAsync();

            return product.Id;
        }

        // UPDATE
        public async Task<bool> UpdateAsync(Guid id, string name, decimal price)
        {
            var product = await _uow.Products.GetByIdAsync(id);
            if (product is null)
                return false;

            product.Name = name;
            product.Price = price;

            _uow.Products.Update(product);
            await _uow.SaveChangesAsync();

            return true;
        }

        // DELETE
        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _uow.Products.GetByIdAsync(id);
            if (product is null)
                return false;

            _uow.Products.Delete(product);
            await _uow.SaveChangesAsync();

            return true;
        }
    }
}
