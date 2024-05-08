using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.Features.Order.Request.Commands;
using MyEshop_Clean.Application.Features.Order.Request.Queries;
using MyEshop_Clean.Application.Features.Order.Requests.Queries;
using MyEshop_Clean.Application.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyEshop_Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> Get()
        {
            var orders = await _mediator.Send(new GetOrderListRequest());
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var order = await _mediator.Send(new GetOrderDetailRequest());
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOrderDto createOrderDto)
        {
            var command = new CreateOrderCommand() { CreateOrderDto = createOrderDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateOrderDto updateOrderDto)
        {
            var command = new UpdateOrderCommand() {UpdateOrderDto = updateOrderDto};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOrderCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
