using explore_pattern.Api.Models.Dtos.Models;

namespace explore_pattern.Api.Interfaces.Persistences.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDescListDto>> GetProductDescList();
    }

}
