using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Features.Product.Feature.Requests.Queries;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Features.Product.Feature.Handlers.Queries
{
    public class GetProductFeaturesRequestHandler : IRequestHandler<GetProductFeaturesRequest, List<ProductFeature>>
    {
        private readonly IProductFeatureRepository _productFeatureRepository;

        public GetProductFeaturesRequestHandler(IProductFeatureRepository productFeatureRepository)
        {
            _productFeatureRepository = productFeatureRepository;
        }
        public async Task<List<ProductFeature>> Handle(GetProductFeaturesRequest request, CancellationToken cancellationToken)
        {
            return await _productFeatureRepository.GetProductFeaturesAsync(request.ProductId);
        }
    }
}
