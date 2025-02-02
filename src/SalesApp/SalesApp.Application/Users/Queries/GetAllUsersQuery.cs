using MediatR;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Users.Queries
{
    public class GetAllUsersQuery: IRequest<Result<List<User>>>
    {
    }
}
