using explore_pattern.Api.Models.Entities;
using explore_pattern.Api.Repositories;
using explore_pattern.Api.Utilities.Helpers;
using explore_pattern.Api_tests.TestArranges;

namespace explore_pattern.Api_tests.Repositories
{
    public class ProductRepositoryTests : ContextTestBase
    {
        #region prop and ctor
        private const string _className = nameof(ProductRepositoryTests);
        #endregion

        #region main test
        [Fact]
        public async Task GetProductDescList_Should_Return_Product_With_Category_And_Store()
        {
            // Arrange
            using var context = Create($"{_className}-{Common.GetMethodName()}");

            var store = new Store
            {
                Id = Guid.NewGuid(),
                Name = "Main Store"
            };

            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Electronics",
                StoreId = store.Id,
                Store = store
            };

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                Price = 15000000,
                CategoryId = category.Id,
                Category = category
            };

            context.Stores.Add(store);
            context.Categories.Add(category);
            context.Products.Add(product);
            await context.SaveChangesAsync();

            var repository = new ProductRepository(context);

            // Act
            var result = (await repository.GetProductDescList()).ToList();

            // Assert
            Assert.Single(result);

            var dto = result[0];
            Assert.Equal(product.Id, dto.Id);
            Assert.Equal("Laptop", dto.ProductName);
            Assert.Equal(15000000, dto.Price);
            Assert.Equal("Electronics", dto.CategoryName);
            Assert.Equal("Main Store", dto.StoreName);
        }
        #endregion
    }
}
