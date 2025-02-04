using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Commands.Handlers
{
    internal class CancelSaleCommandHandler: IRequestHandler<CancelSaleCommand, Result<ResultMessage>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleRepository _saleRepository;

        public CancelSaleCommandHandler(
            IUnitOfWork unitOfWork,
            ISaleRepository saleRepository
            )
        {
            _unitOfWork = unitOfWork;
            _saleRepository = saleRepository;
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

                return new ResultMessage("Sale cancelled with success.");
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
