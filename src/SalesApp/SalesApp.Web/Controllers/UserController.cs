using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Application.Users.Commands;
using SalesApp.Application.Users.Queries;
using SalesApp.Web.Extensions;

namespace SalesApp.Web.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync(int _page = 1, int _size = 10, string _order = "")
        {
            var result = await _mediator.Send(new GetAllUsersQuery()
            {
                page = _page,
                size = _size,
                order = _order
            });
            return this.HandleResult(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserAsync(int userId)
        {
            var result = await _mediator.Send(new GetUserByIdQuery() { UserId = userId});
            return this.HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserCommand request)
        {
            var result = await _mediator.Send(request);
            return this.HandleResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserCommand request)
        {
            var result = await _mediator.Send(request);
            return this.HandleResult(result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            var result = await _mediator.Send(new DeleteUserByIdCommand() { UserId = userId});
            return this.HandleResult(result);
        }
    }
}
