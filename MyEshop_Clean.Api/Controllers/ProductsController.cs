using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEshop_Clean.Application.DTOs.Product;
using MyEshop_Clean.Application.Features.Product.Request.Commands;
using MyEshop_Clean.Application.Features.Product.Request.Queries;
using MyEshop_Clean.Application.Features.Product.Requests.Queries;
using MyEshop_Clean.Application.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyEshop_Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            var products = await _mediator.Send(new GetProductListRequest());

            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductDetailRequest() { Id = id });

            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductDto createProductDto)
        {
            var command = new CreateProductCommand() { CreateProductDto = createProductDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var command = new UpdateProductCommand() { UpdateProductDto = updateProductDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
