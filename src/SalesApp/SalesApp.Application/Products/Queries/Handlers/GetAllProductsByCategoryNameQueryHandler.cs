using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;
using SalesApp.Domain.Entities;

namespace SalesApp.Application.Products.Queries.Handlers
{
    internal class GetAllProductsByCategoryNameQueryHandler: IRequestHandler<GetAllProductsByCategoryNameQuery, Result<List<Product>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsByCategoryNameQueryHandler(
            IProductRepository productRepository
            )
        {
            _productRepository = productRepository;
        }

        public async Task<Result<List<Product>>> Handle(GetAllProductsByCategoryNameQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _productRepository.GetAllWithCategory(query.categoryName, query.page, query.size, query.order);
                return list;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
