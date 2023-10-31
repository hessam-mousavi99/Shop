using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.DTOs.Site;
using Shop.Application.Features.Product.Product.Requests.Queries;

namespace Shop.Application.Features.Product.Product.Handlers.Queries
{
    public class GetRelatedProductRequestHandler : IRequestHandler<GetRelatedProductRequest, List<ProductItemDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetRelatedProductRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductItemDto>> Handle(GetRelatedProductRequest request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetRelatedProduct(request.CategoryName, request.ProductId);
        }
    }
}
