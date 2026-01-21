using explore_pattern.Domain.Dtos.Models;

namespace explore_pattern.Domain.Interfaces.Persistences.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDescListDto>> GetProductDescList();
    }

}
