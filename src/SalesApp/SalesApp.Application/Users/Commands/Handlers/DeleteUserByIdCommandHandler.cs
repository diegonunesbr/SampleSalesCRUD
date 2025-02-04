using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Users.Commands.Handlers
{
    internal class DeleteUserByIdCommandHandler: IRequestHandler<DeleteUserByIdCommand, Result<ResultMessage>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public DeleteUserByIdCommandHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository
            )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<Result<ResultMessage>> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await _userRepository.GetById(command.UserId);
                if(user == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "User not found", $"There is no user with id {command.UserId}");
                }

                _userRepository.Delete(user);
                await _unitOfWork.CommitAsync();

                return new ResultMessage("User deleted with success.");
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
