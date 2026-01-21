using explore_pattern.Application.Commands.Stores.CreateStore;
using explore_pattern.Application.Queries.Stores.GetStoreById;
using explore_pattern.Application.Queries.Stores.GetStoreList;
using Microsoft.AspNetCore.Mvc;

namespace explore_pattern.Api.Controllers
{
    [ApiController]
    [Route("api/stores")]
    public class StoresController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateStoreCommand command,
            [FromServices] CreateStoreHandler handler)
        {
            var result = await handler.Handle(command);
            return StatusCode(result.Status.Code, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] GetStoreListHandler handler)
        {
            var result = await handler.Handle();
            return StatusCode(result.Status.Code, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            Guid id,
            [FromServices] GetStoreByIdHandler handler)
        {
            var result = await handler.Handle(new(id));
            return StatusCode(result.Status.Code, result);
        }
    }

}
