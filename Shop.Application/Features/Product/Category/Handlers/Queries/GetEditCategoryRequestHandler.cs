using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.Features.Product.Category.Requests.Commands;

namespace Shop.Application.Features.Product.Category.Handlers.Queries
{
    public class GetEditCategoryRequestHandler : IRequestHandler<GetEditCategoryRequest, EditCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetEditCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<EditCategoryDto> Handle(GetEditCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.CategoryId);
            var editCategory = new EditCategoryDto();
            if (category!=null)
            {
                editCategory.CategoryId = category.Id;
                editCategory.ImageName = category.ImageName;
                editCategory.Title = category.Title;
                editCategory.UrlName = category.UrlName;
            }
            return editCategory;
        }
    }
}
