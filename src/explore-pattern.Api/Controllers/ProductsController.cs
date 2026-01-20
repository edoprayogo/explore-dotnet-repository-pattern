using explore_pattern.Application.Services;
using explore_pattern.Domain.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace explore_pattern.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        #region prop and ctor
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _service.GetByIdAsync(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var id = await _service.CreateAsync(
                request.CategoryId,
                request.Name,
                request.Price);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductRequest request)
        {
            var success = await _service.UpdateAsync(id, request.Name, request.Price);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
