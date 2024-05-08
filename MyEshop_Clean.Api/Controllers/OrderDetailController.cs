using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.Features.Order.Request.Commands;
using MyEshop_Clean.Application.Features.OrderDetail.Request.Commands;
using MyEshop_Clean.Application.Features.OrderDetail.Request.Queries;
using MyEshop_Clean.Application.Features.OrderDetail.Requests.Queries;
using MyEshop_Clean.Application.Response;
using MyEshop_Clean.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyEshop_Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<OrderDetailController>
        [HttpGet]
        public async Task<ActionResult<List<OrderDetail>>> Get()
        {
            var orderDetails = await _mediator.Send(new GetOrderDetailListRequest());
            return Ok(orderDetails);
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> Get(int id)
        {
            var orderDetail = await _mediator.Send(new GetOrderDetailDetailRequest(){Id = id});
            return Ok(orderDetail);
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOrderDetailDto createOrderDetailDto)
        {
            var command = new CreateOrderDetailCommand() { CreateOrderDetailDto = createOrderDetailDto };
            var response = await _mediator.Send(command);
            return Ok(response);    
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateOrderDetailDto updateOrderDetailDto)
        {
            var command = new UpdateOrderDetailCommand() { UpdateOrderDetailDto = updateOrderDetailDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOrderDetailCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
