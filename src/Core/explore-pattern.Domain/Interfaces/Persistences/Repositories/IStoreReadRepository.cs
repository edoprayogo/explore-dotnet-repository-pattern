using explore_pattern.Domain.Entities;

namespace explore_pattern.Domain.Interfaces.Persistences.Repositories
{
    public interface IStoreReadRepository
    {
        Task<IEnumerable<Store>> GetAllAsync();
        Task<Store?> GetByIdAsync(Guid id);
    }
}
