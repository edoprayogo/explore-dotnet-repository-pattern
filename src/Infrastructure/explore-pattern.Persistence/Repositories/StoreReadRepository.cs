using explore_pattern.Domain.Entities;
using explore_pattern.Domain.Interfaces.Persistences.Repositories;
using explore_pattern.Persistence.Databases;
using Microsoft.EntityFrameworkCore;

namespace explore_pattern.Persistence.Repositories
{
    public class StoreReadRepository : IStoreReadRepository
    {
        private readonly DemoStoreDbContext _context;

        public StoreReadRepository(DemoStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
            => await _context.Stores
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ToListAsync();

        public async Task<Store?> GetByIdAsync(Guid id)
            => await _context.Stores.FindAsync(id);
    }

}
