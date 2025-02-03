using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Application.Carts.Commands;
using SalesApp.Application.Carts.Queries;
using SalesApp.Web.Extensions;

namespace SalesApp.Web.Controllers
{
    [ApiController]
    [Route("carts")]
    public class CartController: ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartsAsync(int _page = 1, int _size = 10, string _order = "")
        {
            var result = await _mediator.Send(new GetAllCartsQuery()
            {
                page = _page,
                size = _size,
                order = _order
            });
            return this.HandleResult(result);
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetCartAsync(int cartId)
        {
            var result = await _mediator.Send(new GetCartByIdQuery() { CartId = cartId});
            return this.HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartAsync(CreateCartCommand request)
        {
            var result = await _mediator.Send(request);
            return this.HandleResult(result);
        }

        [HttpPut("{cartId}")]
        public async Task<IActionResult> UpdateCartAsync(int cartId, [FromBody] UpdateCartCommand request)
        {
            request.id = cartId;
            var result = await _mediator.Send(request);
            return this.HandleResult(result);
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> DeletCartAsync(int cartId)
        {
            var result = await _mediator.Send(new DeleteCartByIdCommand() { CartId = cartId});
            return this.HandleResult(result);
        }
    }
}
