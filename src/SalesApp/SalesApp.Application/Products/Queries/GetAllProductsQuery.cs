using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Products.Queries
{
    public class GetAllProductsQuery: IRequest<Result<List<Product>>>
    {
        public int page { get; set; }
        public int size { get; set; }
        public string order { get; set; } = string.Empty;
    }
}
