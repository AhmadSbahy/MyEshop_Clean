using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyEshop_Clean.Application.DTOs.User;
using MyEshop_Clean.Application.Features.User.Requests.Commands;
using MyEshop_Clean.Application.Features.User.Requests.Queries;
using MyEshop_Clean.Application.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyEshop_Clean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            var users = await _mediator.Send(new GetUserListRequest());
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {   
            var user = await _mediator.Send(new GetUserDetailRequest(){Id = id});
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateUserDto createUserDto)
        {
            var command = new CreateUserCommand(){CreateUserDto = createUserDto};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var command = new UpdateUserCommand() { UpdateUserDto = updateUserDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
