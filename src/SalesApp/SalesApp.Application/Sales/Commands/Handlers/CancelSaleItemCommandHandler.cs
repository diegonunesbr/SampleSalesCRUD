using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Application.Sales.Events;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Commands.Handlers
{
    internal class CancelSaleItemCommandHandler: IRequestHandler<CancelSaleItemCommand, Result<ResultMessage>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleRepository _saleRepository;
        private readonly IMessageBus _messageBus;

        public CancelSaleItemCommandHandler(
            IUnitOfWork unitOfWork,
            ISaleRepository saleRepository,
            IMessageBus messageBus
            )
        {
            _unitOfWork = unitOfWork;
            _saleRepository = saleRepository;
            _messageBus = messageBus;
        }

        public async Task<Result<ResultMessage>> Handle(CancelSaleItemCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Sale? sale = await _saleRepository.GetById(command.saleId);
                if(sale == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Sale not found", $"There is no sale with id {command.saleId}");
                }
                _saleRepository.LoadItems(sale);

                SaleItem? item = sale.products.Where(x => x.productId == command.productId).FirstOrDefault();
                if(item == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Product not found", $"There is no product with id {command.productId} on sale id {command.saleId}");
                }

                sale.products.Remove(item);

                if(sale.products.Count == 0)
                {
                    return new ResultError(ResultError.ValidationError, "Sale can't be empty");
                }

                sale.CalculateSaleDiscount();

                _saleRepository.Update(sale);
                await _unitOfWork.CommitAsync();

                ItemCancelledEvent evt = new ItemCancelledEvent()
                {
                    sale = sale,
                    cancelledItem = item
                };
                _messageBus.Send(evt);

                return new ResultMessage("Sale item cancelled with success.");
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
