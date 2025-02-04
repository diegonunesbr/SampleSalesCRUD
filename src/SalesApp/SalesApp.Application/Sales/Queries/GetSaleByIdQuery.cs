using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Queries
{
    public class GetSaleByIdQuery: IRequest<Result<Sale>>
    {
        public int SaleId { get; set; }
    }
}
