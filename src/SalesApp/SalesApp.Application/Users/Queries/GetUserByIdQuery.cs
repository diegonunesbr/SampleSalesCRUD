using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Users.Queries
{
    public class GetUserByIdQuery: IRequest<Result<User>>
    {
        public int UserId { get; set; }
    }
}
