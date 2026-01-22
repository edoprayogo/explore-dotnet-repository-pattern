using explore_pattern.Api.Interfaces.Persistences;
using explore_pattern.Api.Models.BaseModels;
using explore_pattern.Api.Models.Dtos.Models;
using explore_pattern.Api.Models.Entities;
using explore_pattern.Api.Utilities.Constants;
using explore_pattern.Api.Utilities.Helpers;

namespace explore_pattern.Api.Services
{
    public class ProductService
    {
        #region prop and ctor
        private readonly IUnitOfWork _uow;
        private const string _entityName = "Products";
        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        #endregion

        // READ ALL
        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _uow.Products.GetAllAsync();
            return products is null
                ? Enumerable.Empty<Product>()
                : products;
        }

        // READ BY ID
        public async Task<Result<Product>> GetById(Guid id)
        {
            var product = await _uow.Products.GetByIdAsync(id);

            return product is null
                ? Result<Product>.Failure(MessageFormatter.Format(StatusMessage.NotFoundData, _entityName))
                : Result<Product>.Success(product);
        }



        // CREATE
        public async Task<Guid> Create(Guid categoryId, string name, decimal price)
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
        public async Task<bool> Update(Guid id, string name, decimal price)
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
        public async Task<bool> Delete(Guid id)
        {
            var product = await _uow.Products.GetByIdAsync(id);
            if (product is null)
                return false;

            _uow.Products.Delete(product);
            await _uow.SaveChangesAsync();

            return true;
        }

        // GET PRODUCT DESC LIST
        public async Task<IEnumerable<ProductDescListDto>> GetProductDescList()
        {
            var products = await _uow.ProductQueries.GetProductDescList();
            return products is null
                ? Enumerable.Empty<ProductDescListDto>()
                : products;
        }
    }
}
