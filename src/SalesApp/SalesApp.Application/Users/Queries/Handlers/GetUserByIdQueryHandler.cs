using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Users.Queries.Handlers
{
    internal class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery, Result<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(
            IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetById(query.UserId);
                if(user == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "User not found", $"There is no user with id {query.UserId}");
                }
                return user;
            } catch(Exception ex)
            {
                return new ResultError(ResultError.InternalServerError, ex.Message, ex.StackTrace);
            }
        }
    }
}
