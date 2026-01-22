using explore_pattern.Api.Models.Entities;

namespace explore_pattern.Api_tests.TestArranges
{
    public static class EntityArrange
    {
        public static Guid ProductId = Guid.NewGuid();

        public static Category _electornicsCategory = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Electronics",
            StoreId = Guid.NewGuid()
        };

        public static Product _laptopProduct = new Product
        {
            Id = ProductId,
            Name = "Laptop",
            Price = 15000000,
            CategoryId = _electornicsCategory.Id,
            Category = _electornicsCategory
        };

        public static Product _phoneProduct = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Phone",
            Price = 8000000,
            CategoryId = _electornicsCategory.Id,
            Category = _electornicsCategory
        };

        public static Product _tabletProduct = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Tablet",
            Price = 6000000,
            CategoryId = _electornicsCategory.Id,
            Category = _electornicsCategory
        };

    }
}
