using explore_pattern.Domain.Commons;
using explore_pattern.Domain.Entities;
using explore_pattern.Domain.Interfaces.Persistences.Repositories;

namespace explore_pattern.Application.Queries.Stores.GetStoreList
{
    public class GetStoreListHandler
    {
        private readonly IStoreReadRepository _repo;

        public GetStoreListHandler(IStoreReadRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<IEnumerable<Store>>> Handle()
        {
            var data = await _repo.GetAllAsync();

            return data.Any()
                ? ApiResponse<IEnumerable<Store>>.Success(data)
                : ApiResponse<IEnumerable<Store>>.NotFound();
        }
    }


}
