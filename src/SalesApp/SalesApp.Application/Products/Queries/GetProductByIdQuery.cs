using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Products.Queries
{
    public class GetProductByIdQuery: IRequest<Result<Product>>
    {
        public int ProductId { get; set; }
    }
}
