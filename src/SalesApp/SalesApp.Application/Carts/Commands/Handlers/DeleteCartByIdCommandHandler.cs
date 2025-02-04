using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Carts.Commands.Handlers
{
    internal class DeleteCartByIdCommandHandler: IRequestHandler<DeleteCartByIdCommand, Result<ResultMessage>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepository _cartRepository;

        public DeleteCartByIdCommandHandler(
            IUnitOfWork unitOfWork,
            ICartRepository cartRepository
            )
        {
            _unitOfWork = unitOfWork;
            _cartRepository = cartRepository;
        }

        public async Task<Result<ResultMessage>> Handle(DeleteCartByIdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Cart? cart = await _cartRepository.GetById(command.CartId);
                if(cart == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Cart not found", $"There is no cart with id {command.CartId}");
                }

                _cartRepository.Delete(cart);
                await _unitOfWork.CommitAsync();

                return new ResultMessage("Cart deleted with success.");
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
