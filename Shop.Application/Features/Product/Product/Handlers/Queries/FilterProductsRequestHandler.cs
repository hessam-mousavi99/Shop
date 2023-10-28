using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.Features.Product.Product.Requests.Queries;

namespace Shop.Application.Features.Product.Product.Handlers.Queries
{
    public class FilterProductsRequestHandler : IRequestHandler<FilterProductsRequest, FilterProductsDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public FilterProductsRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<FilterProductsDto> Handle(FilterProductsRequest request, CancellationToken cancellationToken)
        {
            return await _productRepository.FilterProducts(request.filterProductsDto);
        }
    }
}
