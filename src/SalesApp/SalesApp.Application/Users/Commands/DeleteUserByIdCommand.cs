using MediatR;
using SalesApp.Application.Models;

namespace SalesApp.Application.Users.Commands
{
    public class DeleteUserByIdCommand: IRequest<Result<ResultMessage>>
    {
        public int UserId { get; set; }
    }
}
