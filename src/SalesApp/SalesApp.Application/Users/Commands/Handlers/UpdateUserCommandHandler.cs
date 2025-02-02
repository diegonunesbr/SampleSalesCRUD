using AutoMapper;
using FluentValidation;
using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Users.Commands.Handlers
{
    internal class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand, Result<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UpdateUserCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IValidator<UpdateUserCommand> validator,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<User>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await _userRepository.GetById(command.id);
                if(user == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "User not found", $"There is no user with id {command.id}");
                }

                var validationResult = await _validator.ValidateAsync(command);
                if(!validationResult.IsValid)
                {
                    return new ResultError(ResultError.ValidationError, "Invalid input data", validationResult.Errors[0].ErrorMessage);
                }

                _mapper.Map(command, user);

                _userRepository.Update(user);
                await _unitOfWork.CommitAsync();

                return user;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
