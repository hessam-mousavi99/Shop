using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.Features.Product.Category.Requests.Queries;

namespace Shop.Application.Features.Product.Category.Handlers.Queries
{
    public class FilterCategoryRequestHandler : IRequestHandler<FilterCategoryRequest, FilterCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public FilterCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<FilterCategoryDto> Handle(FilterCategoryRequest request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.FilterCategoryAsync(request.FilterCategoryDto);
        }
    }
}
