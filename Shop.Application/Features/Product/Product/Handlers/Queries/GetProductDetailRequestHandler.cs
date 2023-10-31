using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.DTOs.Site;
using Shop.Application.Features.Product.Product.Requests.Queries;

namespace Shop.Application.Features.Product.Product.Handlers.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailRequest, ProductDetailDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductDetailRequestHandler(IProductRepository productRepository)
        {
           _productRepository = productRepository;
        }
        public async Task<ProductDetailDto> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            return await _productRepository.ShowProductDetailAsync(request.ProductId);
        }
    }
}
