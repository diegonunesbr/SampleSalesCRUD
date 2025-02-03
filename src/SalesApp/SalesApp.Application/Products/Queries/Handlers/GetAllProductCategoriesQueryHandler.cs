using MediatR;
using SalesApp.Application.Interfaces;
using SalesApp.Application.Models;

namespace SalesApp.Application.Products.Queries.Handlers
{
    internal class GetAllProductCategoriesQueryHandler: IRequestHandler<GetAllProductCategoriesQuery, Result<List<string>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductCategoriesQueryHandler(
            IProductRepository productRepository
            )
        {
            _productRepository = productRepository;
        }

        public async Task<Result<List<string>>> Handle(GetAllProductCategoriesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _productRepository.GetAllCategories();
                return list;
            } catch(Exception ex)
            {
                return new ResultError(ex);
            }
        }
    }
}
