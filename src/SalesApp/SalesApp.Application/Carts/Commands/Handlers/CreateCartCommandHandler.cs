using AutoMapper;
using FluentValidation;
using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Carts.Commands.Handlers
{
    internal class CreateCartCommandHandler: IRequestHandler<CreateCartCommand, Result<Cart>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepository _cartRepository;
        private readonly IValidator<CreateCartCommand> _validator;
        private readonly IMapper _mapper;

        public CreateCartCommandHandler(
            IUnitOfWork unitOfWork,
            ICartRepository cartRepository,
            IValidator<CreateCartCommand> validator,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _cartRepository = cartRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<Cart>> Handle(CreateCartCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(command);
                if(!validationResult.IsValid)
                {
                    return new ResultError(ResultError.ValidationError, "Invalid input data", validationResult.Errors[0].ErrorMessage);
                }

                Cart cart = _mapper.Map<Cart>(command);

                _cartRepository.Add(cart);
                await _unitOfWork.CommitAsync();

                return cart;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
