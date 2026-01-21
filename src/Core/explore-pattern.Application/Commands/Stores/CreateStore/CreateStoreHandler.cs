using explore_pattern.Domain.Commons;
using explore_pattern.Domain.Entities;
using explore_pattern.Domain.Interfaces.Persistences;

namespace explore_pattern.Application.Commands.Stores.CreateStore
{
    public class CreateStoreHandler
    {
        private readonly IUnitOfWork _uow;

        public CreateStoreHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ApiResponse<Guid>> Handle(CreateStoreCommand command)
        {
            var store = new Store
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                CreatedAt = DateTime.UtcNow
            };

            await _uow.Stores.AddAsync(store);
            await _uow.SaveChangesAsync();

            return ApiResponse<Guid>.Success(store.Id);
        }
    }

}
