using explore_pattern.Application.Abstractions;
using explore_pattern.Domain.Commons;
using explore_pattern.Domain.Entities;
using explore_pattern.Domain.Interfaces.Persistences.Repositories;

namespace explore_pattern.Application.Queries.Stores.GetStoreById
{
    public class GetStoreByIdHandler
    : IQueryHandler<GetStoreByIdQuery, ApiResponse<Store?>>
    {
        private readonly IStoreReadRepository _repo;

        public GetStoreByIdHandler(IStoreReadRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<Store?>> Handle(GetStoreByIdQuery query)
        {
            var data = await _repo.GetByIdAsync(query.Id);
            return data is null 
                ? ApiResponse<Store?>.NotFound()
                : ApiResponse<Store?>.Success(data);
        }
    }

}
