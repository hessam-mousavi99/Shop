using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.Features.Product.Product.Requests.Queries;

namespace Shop.Application.Features.Product.Product.Handlers.Queries
{
    public class GetEditProductRequestHandler : IRequestHandler<GetEditProductRequest, EditProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetEditProductRequestHandler(IProductRepository productRepository ,IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public async Task<EditProductDto> Handle(GetEditProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.Id);
            if (product != null)
            {
                var productDto = _mapper.Map<EditProductDto>(product);
                productDto.ProductSelectedCategory = await _productCategoryRepository.GetAllProductCategoryId(request.Id);
                return productDto;
            }
            return null;
        }
    }
}
