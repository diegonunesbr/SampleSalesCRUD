using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Application.Sales.Commands;
using SalesApp.Application.Sales.Queries;
using SalesApp.Web.Extensions;

namespace SalesApp.Web.Controllers
{
    [ApiController]
    [Route("sales")]
    public class SaleController: ControllerBase
    {
        private readonly IMediator _mediator;

        public SaleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{saleId}")]
        public async Task<IActionResult> GetCartAsync(int saleId)
        {
            var result = await _mediator.Send(new GetSaleByIdQuery() { SaleId = saleId});
            return this.HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartAsync(CreateSaleCommand request)
        {
            var result = await _mediator.Send(request);
            return this.HandleResult(result);
        }

        [HttpPut("{saleId}")]
        public async Task<IActionResult> UpdateCartAsync(int saleId, [FromBody] UpdateSaleCommand request)
        {
            request.id = saleId;
            var result = await _mediator.Send(request);
            return this.HandleResult(result);
        }

        [HttpPatch("{saleId}/cancelsale")]
        public async Task<IActionResult> CancelSaleAsync(int saleId)
        {
            var result = await _mediator.Send(new CancelSaleCommand() { SaleId = saleId});
            return this.HandleResult(result);
        }

        [HttpPatch("{saleId}/cancelsaleitem/{productId}")]
        public async Task<IActionResult> CancelSaleItemAsync(int saleId, int productId)
        {
            var result = await _mediator.Send(new CancelSaleItemCommand() { saleId = saleId, productId = productId});
            return this.HandleResult(result);
        }
    }
}
