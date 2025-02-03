using MediatR;
using SalesApp.Application.Models;

namespace SalesApp.Application.Carts.Commands
{
    public class DeleteCartByIdCommand: IRequest<Result<ResultMessage>>
    {
        public int CartId { get; set; }
    }
}
