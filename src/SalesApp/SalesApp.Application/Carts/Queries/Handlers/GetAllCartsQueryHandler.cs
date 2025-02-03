using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Carts.Queries.Handlers
{
    internal class GetAllCartsQueryHandler: IRequestHandler<GetAllCartsQuery, Result<List<Cart>>>
    {
        private readonly ICartRepository _cartRepository;

        public GetAllCartsQueryHandler(
            ICartRepository cartRepository
            )
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result<List<Cart>>> Handle(GetAllCartsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _cartRepository.GetAll(query.page, query.size, query.order);
                list.ForEach(x => _cartRepository.LoadItems(x));
                return list;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
