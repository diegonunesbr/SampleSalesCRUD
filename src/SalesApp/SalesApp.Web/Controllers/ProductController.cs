using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Application.Products.Commands;
using SalesApp.Application.Products.Queries;
using SalesApp.Web.Extensions;

namespace SalesApp.Web.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController: ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync(int _page = 1, int _size = 10, string _order = "")
        {
            var result = await _mediator.Send(new GetAllProductsQuery()
            {
                page = _page,
                size = _size,
                order = _order
            });
            return this.HandleResult(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductAsync(int productId)
        {
            var result = await _mediator.Send(new GetProductByIdQuery() { ProductId = productId});
            return this.HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductCommand request)
        {
            var result = await _mediator.Send(request);
            return this.HandleResult(result);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProductAsync(int productId, [FromBody] UpdateProductCommand request)
        {
            request.id = productId;
            var result = await _mediator.Send(request);
            return this.HandleResult(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            var result = await _mediator.Send(new DeleteProductByIdCommand() { ProductId = productId});
            return this.HandleResult(result);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllProductCategoriesAsync()
        {
            var result = await _mediator.Send(new GetAllProductCategoriesQuery());
            return this.HandleResult(result);
        }

        [HttpGet("categories/{categoryName}")]
        public async Task<IActionResult> GetAllProductsByCategoryNameAsync(string categoryName, int _page = 1, int _size = 10, string _order = "")
        {
            var result = await _mediator.Send(new GetAllProductsByCategoryNameQuery() { 
                categoryName = categoryName ,
                page = _page,
                size = _size,
                order = _order
            });
            return this.HandleResult(result);
        }
    }
}
