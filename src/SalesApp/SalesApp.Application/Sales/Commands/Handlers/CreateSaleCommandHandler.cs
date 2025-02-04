using AutoMapper;
using FluentValidation;
using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Application.Sales.Events;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Commands.Handlers
{
    internal class CreateSaleCommandHandler: IRequestHandler<CreateSaleCommand, Result<Sale>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleRepository _saleRepository;
        private readonly IValidator<CreateSaleCommand> _validator;
        private readonly IMapper _mapper;
        private readonly IMessageBus _messageBus;

        public CreateSaleCommandHandler(
            IUnitOfWork unitOfWork,
            ISaleRepository saleRepository,
            IValidator<CreateSaleCommand> validator,
            IMapper mapper,
            IMessageBus messageBus
            )
        {
            _unitOfWork = unitOfWork;
            _saleRepository = saleRepository;
            _validator = validator;
            _mapper = mapper;
            _messageBus = messageBus;
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

                Sale sale = _mapper.Map<Sale>(command);
                sale.CalculateSaleDiscount();

                _saleRepository.Add(sale);
                await _unitOfWork.CommitAsync();

                SaleCreatedEvent evt = new SaleCreatedEvent()
                {
                    sale = sale
                };
                _messageBus.Send(evt);

                return sale;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
