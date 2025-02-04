using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Carts.Queries
{
    public class GetAllCartsQuery: IRequest<Result<List<Cart>>>
    {
        public int page { get; set; }
        public int size { get; set; }
        public string order { get; set; } = string.Empty;
    }
}
