using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Products.Queries.Handlers
{
    internal class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, Result<List<Product>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(
            IProductRepository productRepository
            )
        {
            _productRepository = productRepository;
        }

        public async Task<Result<List<Product>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _productRepository.GetAll(query.page, query.size, query.order);
                return list;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
