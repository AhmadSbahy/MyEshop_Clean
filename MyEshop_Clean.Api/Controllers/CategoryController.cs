using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.Features.Category.Request.Commands;
using MyEshop_Clean.Application.Features.Category.Request.Queries;
using MyEshop_Clean.Application.Features.Category.Requests.Queries;
using MyEshop_Clean.Application.Features.CategoryToProduct.Request;
using MyEshop_Clean.Application.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyEshop_Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
			var categories = await _mediator.Send(new GetCategoryListRequest());
			return Ok(categories);
		}

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await _mediator.Send(new GetCategoryDetailRequest(){Id = id});
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCategoryDto createCategoryDto)
        {
            var command = new CreateCategoryCommand() { CreateCategoryDto = createCategoryDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var command = new UpdateCategoryCommand() { UpdateCategoryDto = updateCategoryDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
