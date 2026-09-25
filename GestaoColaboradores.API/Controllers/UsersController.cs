using GestaoColaboradores.Application.Commands.CreateUser;
using GestaoColaboradores.Application.Commands.DeleteUser;
using GestaoColaboradores.Application.Commands.Register;
using GestaoColaboradores.Application.Commands.UpdateUser;
using GestaoColaboradores.Application.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoColaboradores.API.Controllers
{
        [Authorize]
        [ApiController]
        [Route("api/[controller]")]
        public class UsersController : ControllerBase
        {
            private readonly IMediator _mediator;

            public UsersController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _mediator.Send(new GetUsersQuery());
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
            {
                var result = await _mediator.Send(command);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
            {
                command.Id = id;
                var result = await _mediator.Send(command);
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _mediator.Send(new DeleteUserCommand(id));
                return result.IsSuccess ? Ok(result) : BadRequest(result);
            }

            

        }
}

