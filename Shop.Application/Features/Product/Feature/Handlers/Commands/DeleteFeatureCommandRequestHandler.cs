using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Features.Product.Feature.Requests.Commands;

namespace Shop.Application.Features.Product.Feature.Handlers.Commands
{
    public class DeleteFeatureCommandRequestHandler : IRequestHandler<DeleteFeatureCommandRequest>
    {
        private readonly IProductFeatureRepository _productFeatureRepository;

        public DeleteFeatureCommandRequestHandler(IProductFeatureRepository productFeatureRepository)
        {
            _productFeatureRepository = productFeatureRepository;
        }
        public async Task<Unit> Handle(DeleteFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            var feature = await _productFeatureRepository.GetAsync(request.Id);
            if (feature != null)
            {
                feature.IsDelete=true;
                await _productFeatureRepository.UpdateAsync(feature);
            }
            return Unit.Value;
        }
    }
}
