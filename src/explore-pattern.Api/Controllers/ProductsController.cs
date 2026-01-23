using explore_pattern.Api.Models.BaseModels;
using explore_pattern.Api.Models.Dtos.Requests;
using explore_pattern.Api.Models.Entities;
using explore_pattern.Api.Services;
using explore_pattern.Api.Utilities.Constants;
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
        {
            var result = await _service.GetAll();

            var message = result.Any()
                ? StatusMessage.SuccessString
                : StatusMessage.NotFoundData;

            return Ok(ApiResponse<IEnumerable<Product>>.Success(result, message));
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);

            if (!result.IsSuccess)
                return NotFound(ApiResponse<string>.Fail(StatusCodes.Status404NotFound, result.Error!));

            return Ok(ApiResponse<Product>.Success(result.Value!));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var id = await _service.Create(
                request.CategoryId,
                request.Name,
                request.Price);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductRequest request)
        {
            var success = await _service.Update(id, request.Name, request.Price);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            return success ? NoContent() : NotFound();
        }

        [HttpGet]
        [Route("descriptions")]
        public async Task<IActionResult> GetProductDescriptions()
        {
            var result = await _service.GetProductDescList();
            var message = result.Any()
                ? StatusMessage.SuccessString
                : StatusMessage.NotFoundData;
            return Ok(ApiResponse<IEnumerable<object>>.Success(result, message));
        }
    }
}
