using explore_pattern.Domain.Entities;
using explore_pattern.Domain.Interfaces.Persistences.Repositories;
using explore_pattern.Persistence.Databases;

namespace explore_pattern.Persistence.Repositories
{
    public class StoreWriteRepository : IStoreWriteRepository
    {
        private readonly DemoStoreDbContext _context;

        public StoreWriteRepository(DemoStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Store store)
            => await _context.Stores.AddAsync(store);

        public void Update(Store store)
            => _context.Stores.Update(store);

        public void Remove(Store store)
            => _context.Stores.Remove(store);
    }

}
