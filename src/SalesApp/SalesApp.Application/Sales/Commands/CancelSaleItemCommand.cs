using MediatR;
using SalesApp.Application.Models;

namespace SalesApp.Application.Sales.Commands
{
    public class CancelSaleItemCommand: IRequest<Result<ResultMessage>>
    {
        public int saleId { get; set; }
        public int productId { get; set; }
    }
}
