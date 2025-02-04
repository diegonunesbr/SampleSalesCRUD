using MediatR;
using SalesApp.Application.Models;

namespace SalesApp.Application.Sales.Commands
{
    public class CancelSaleCommand: IRequest<Result<ResultMessage>>
    {
        public int SaleId { get; set; }
    }
}
