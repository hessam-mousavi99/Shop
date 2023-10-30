using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Features.Product.Feature.Requests.Commands;
using Shop.Domain.Enums;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Features.Product.Feature.Handlers.Commands
{
    public class CreateFeatureCommandRequestHandler : IRequestHandler<CreateFeatureCommandRequest, CreateFeatuersResult>
    {
        private readonly IProductFeatureRepository _productFeatureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateFeatureCommandRequestHandler(IProductFeatureRepository productFeatureRepository,IProductRepository productRepository, IMapper mapper)
        {
            _productFeatureRepository = productFeatureRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<CreateFeatuersResult> Handle(CreateFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            if(!await _productRepository.CheckProductExist(request.CreateFeatureDto.ProductId))
            {
                return CreateFeatuersResult.Error;
            }
            var newFeature = _mapper.Map<ProductFeature>(request.CreateFeatureDto);
            await _productFeatureRepository.AddAsync(newFeature);
            return CreateFeatuersResult.Success;
        }
    }
}
