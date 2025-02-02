using AutoMapper;
using FluentValidation;
using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Users.Commands.Handlers
{
    internal class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Result<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<CreateUserCommand> _validator;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IValidator<CreateUserCommand> validator,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<User>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(command);
                if(!validationResult.IsValid)
                {
                    return new ResultError(ResultError.ValidationError, "Invalid input data", validationResult.Errors[0].ErrorMessage);
                }

                User user = _mapper.Map<User>(command);

                _userRepository.Add(user);
                await _unitOfWork.CommitAsync();

                return user;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
