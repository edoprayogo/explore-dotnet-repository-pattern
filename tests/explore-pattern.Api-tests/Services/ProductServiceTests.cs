using explore_pattern.Api.Interfaces.Persistences;
using explore_pattern.Api.Models.Entities;
using explore_pattern.Api.Services;
using explore_pattern.Api_tests.TestArranges;

namespace explore_pattern.Api_tests.Services
{
    public class ProductServiceTests
    {
        #region prop and ctor
        private readonly Mock<IUnitOfWork> _mockRepo = new();

        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _service = new ProductService(_mockRepo.Object);
        }
        #endregion

        #region main
        [Fact]
        public async Task GetAll_Ok()
        {
            // Arrange
            var products = new List<Product>() { EntityArrange._laptopProduct, EntityArrange._phoneProduct, EntityArrange._tabletProduct };
            
            _mockRepo.Setup(a => a.Products.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _service.GetAll();

            // Assert
            Assert.Equal(3, result.Count());

        }
        #endregion
    }
}
