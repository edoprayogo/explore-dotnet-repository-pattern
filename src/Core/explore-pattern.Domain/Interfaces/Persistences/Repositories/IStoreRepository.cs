using explore_pattern.Domain.Entities;

namespace explore_pattern.Domain.Interfaces.Persistences.Repositories
{
    public interface IStoreRepository
    {
        Task<Store?> GetAsync(CancellationToken ct);
        Task SaveAsync(Store store, CancellationToken ct);
    }
}
