using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Products.Queries.Handlers
{
    internal class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery, Result<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(
            IProductRepository productRepository
            )
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Product>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _productRepository.GetById(query.ProductId);
                if(user == null)
                {
                    return new ResultError(ResultError.ResourceNotFound, "Product not found", $"There is no product with id {query.ProductId}");
                }
                return user;
            } catch(Exception ex)
            {
                return new ResultError(ResultError.InternalServerError, ex.Message, ex.StackTrace);
            }
        }
    }
}
