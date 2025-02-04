using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Products.Commands.Handlers
{
    internal class DeleteProductByIdCommandHandler: IRequestHandler<DeleteProductByIdCommand, Result<ResultMessage>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public DeleteProductByIdCommandHandler(
            IUnitOfWork unitOfWork,
            IProductRepository productRepository
            )
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<Result<ResultMessage>> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Product? product = await _productRepository.GetById(command.ProductId);
                if(product == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Product not found", $"There is no product with id {command.ProductId}");
                }

                _productRepository.Delete(product);
                await _unitOfWork.CommitAsync();

                return new ResultMessage("Product deleted with success.");
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
