using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Carts.Queries
{
    public class GetCartByIdQuery: IRequest<Result<Cart>>
    {
        public int CartId { get; set; }
    }
}
