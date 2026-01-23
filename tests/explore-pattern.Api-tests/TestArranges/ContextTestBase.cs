using explore_pattern.Api.Databases;
using Microsoft.EntityFrameworkCore;


namespace explore_pattern.Api_tests.TestArranges
{
    public abstract class ContextTestBase
    {
        protected static DemoStoreDbContext Create(string? dbName = null)
        {
            var options = new DbContextOptionsBuilder<DemoStoreDbContext>()
                .UseInMemoryDatabase(dbName ?? Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            var context = new DemoStoreDbContext(options);

            context.Database.EnsureCreated();
            return context;
        }
    }

}

