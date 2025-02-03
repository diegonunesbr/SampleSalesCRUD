using MediatR;
using SalesApp.Application.Models;

namespace SalesApp.Application.Products.Queries
{
    public class GetAllProductCategoriesQuery: IRequest<Result<List<string>>>
    {
    }
}
