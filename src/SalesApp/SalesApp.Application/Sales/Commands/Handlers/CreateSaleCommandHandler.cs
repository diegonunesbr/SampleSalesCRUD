using AutoMapper;
using FluentValidation;
using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Commands.Handlers
{
    internal class CreateSaleCommandHandler: IRequestHandler<CreateSaleCommand, Result<Sale>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleRepository _saleRepository;
        private readonly IValidator<CreateSaleCommand> _validator;
        private readonly IMapper _mapper;

        public CreateSaleCommandHandler(
            IUnitOfWork unitOfWork,
            ISaleRepository saleRepository,
            IValidator<CreateSaleCommand> validator,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _saleRepository = saleRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<Sale>> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(command);
                if(!validationResult.IsValid)
                {
                    return new ResultError(ResultError.ValidationError, "Invalid input data", validationResult.Errors[0].ErrorMessage);
                }

                Sale cart = _mapper.Map<Sale>(command);
                cart.CalculateSaleDiscount();

                _saleRepository.Add(cart);
                await _unitOfWork.CommitAsync();

                return cart;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
