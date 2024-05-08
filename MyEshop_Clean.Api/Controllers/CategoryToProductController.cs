using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyEshop_Clean.Application.DTOs.CategoryToProduct;
using MyEshop_Clean.Application.Features.Category.Request.Commands;
using MyEshop_Clean.Application.Features.Category.Request.Queries;
using MyEshop_Clean.Application.Features.CategoryToProduct.Request;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryToProductController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoryToProductController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/<CategoryToProductController>
		[HttpGet]
		public async Task<ActionResult<List<CategoryToProductDto>>> Get()
		{
			var categories = await _mediator.Send(new GetCategoryToProductListRequest());
			return Ok(categories);
		}

		// GET api/<CategoryToProductController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CategoryToProductController>
		[HttpPost]
		public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCategoryToProductDto createCategoryToProductDto)
		{
			var command = new CreateCategoryToProductCommand() { CreateCategoryToProductDto = createCategoryToProductDto};
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		// PUT api/<CategoryToProductController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateCategoryToProductDto updateCategoryToProductDto)
		{
			var command = new UpdateCategoryToProductCommand() { UpdateCategoryToProductDto = updateCategoryToProductDto};
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		// DELETE api/<CategoryToProductController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteCategoryToProductCommand() { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
