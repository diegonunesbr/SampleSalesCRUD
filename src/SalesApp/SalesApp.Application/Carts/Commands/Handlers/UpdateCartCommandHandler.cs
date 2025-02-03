using AutoMapper;
using FluentValidation;
using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Carts.Commands.Handlers
{
    internal class UpdateCartCommandHandler: IRequestHandler<UpdateCartCommand, Result<Cart>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepository _cartRepository;
        private readonly IValidator<UpdateCartCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateCartCommandHandler(
            IUnitOfWork unitOfWork,
            ICartRepository cartRepository,
            IValidator<UpdateCartCommand> validator,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _cartRepository = cartRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<Cart>> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Cart? cart = await _cartRepository.GetById(command.id);
                if(cart == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Cart not found", $"There is no cart with id {command.id}");
                }

                var validationResult = await _validator.ValidateAsync(command);
                if(!validationResult.IsValid)
                {
                    return new ResultError(ResultError.ValidationError, "Invalid input data", validationResult.Errors[0].ErrorMessage);
                }

                _mapper.Map(command, cart);

                _cartRepository.Update(cart);
                await _unitOfWork.CommitAsync();

                return cart;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
