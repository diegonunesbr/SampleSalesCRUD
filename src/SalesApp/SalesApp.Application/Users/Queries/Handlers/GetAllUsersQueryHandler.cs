using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Users.Queries.Handlers
{
    internal class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQuery, Result<List<User>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(
            IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<User>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _userRepository.GetAll();
                return list;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
