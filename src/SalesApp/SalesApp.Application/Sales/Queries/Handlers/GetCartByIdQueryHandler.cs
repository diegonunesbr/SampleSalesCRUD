using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Sales.Queries.Handlers
{
    internal class GetCartByIdQueryHandler: IRequestHandler<GetSaleByIdQuery, Result<Sale>>
    {
        private readonly ISaleRepository _saleRepository;

        public GetCartByIdQueryHandler(
            ISaleRepository cartRepository
            )
        {
            _saleRepository = cartRepository;
        }

        public async Task<Result<Sale>> Handle(GetSaleByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var sale = await _saleRepository.GetById(query.SaleId);
                if(sale == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Sale not found", $"There is no sale with id {query.SaleId}");
                }
                _saleRepository.LoadItems(sale);
                return sale;
            } catch(Exception ex)
            {
                return new ResultError(ResultError.InternalServerError, ex.Message, ex.StackTrace);
            }
        }
    }
}
