using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Carts.Queries.Handlers
{
    internal class GetCartByIdQueryHandler: IRequestHandler<GetCartByIdQuery, Result<Cart>>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartByIdQueryHandler(
            ICartRepository cartRepository
            )
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result<Cart>> Handle(GetCartByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var cart = await _cartRepository.GetById(query.CartId);
                if(cart == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Cart not found", $"There is no cart with id {query.CartId}");
                }
                _cartRepository.LoadItems(cart);
                return cart;
            } catch(Exception ex)
            {
                return new ResultError(ResultError.InternalServerError, ex.Message, ex.StackTrace);
            }
        }
    }
}
