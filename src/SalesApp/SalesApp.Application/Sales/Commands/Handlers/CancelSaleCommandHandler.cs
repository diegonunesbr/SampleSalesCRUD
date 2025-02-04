using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Application.Sales.Events;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Commands.Handlers
{
    internal class CancelSaleCommandHandler: IRequestHandler<CancelSaleCommand, Result<ResultMessage>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleRepository _saleRepository;
        private readonly IMessageBus _messageBus;

        public CancelSaleCommandHandler(
            IUnitOfWork unitOfWork,
            ISaleRepository saleRepository,
            IMessageBus messageBus
            )
        {
            _unitOfWork = unitOfWork;
            _saleRepository = saleRepository;
            _messageBus = messageBus;
        }

        public async Task<Result<ResultMessage>> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Sale? sale = await _saleRepository.GetById(command.SaleId);
                if(sale == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Sale not found", $"There is no sale with id {command.SaleId}");
                }
                _saleRepository.LoadItems(sale);
                sale.status = Domain.Enums.SaleStatus.Cancelled;
                _saleRepository.Update(sale);
                await _unitOfWork.CommitAsync();

                SaleCancelledEvent evt = new SaleCancelledEvent()
                {
                    sale = sale
                };
                _messageBus.Send(evt);

                return new ResultMessage("Sale cancelled with success.");
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
