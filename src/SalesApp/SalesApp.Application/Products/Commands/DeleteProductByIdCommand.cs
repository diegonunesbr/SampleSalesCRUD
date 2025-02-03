using MediatR;
using SalesApp.Application.Models;

namespace SalesApp.Application.Products.Commands
{
    public class DeleteProductByIdCommand: IRequest<Result<ResultMessage>>
    {
        public int ProductId { get; set; }
    }
}
