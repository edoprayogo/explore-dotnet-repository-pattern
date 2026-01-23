using explore_pattern.Api.Databases;
using explore_pattern.Api.Interfaces.Persistences;
using Microsoft.EntityFrameworkCore;

namespace explore_pattern.Api.UnitOfWorks
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DemoStoreDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DemoStoreDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
            => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.AsNoTracking().ToListAsync();

        public async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);

        public void Update(T entity)
            => _dbSet.Update(entity);

        public void Delete(T entity)
            => _dbSet.Remove(entity);
    }
}
