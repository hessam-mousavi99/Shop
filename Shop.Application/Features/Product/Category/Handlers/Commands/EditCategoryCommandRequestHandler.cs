using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Extentions;
using Shop.Application.Features.Product.Category.Requests.Commands;
using Shop.Application.Utils;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Product.Category.Handlers.Commands
{
    public class EditCategoryCommandRequestHandler : IRequestHandler<EditCategoryCommandRequest, EditCategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public EditCategoryCommandRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<EditCategoryResult> Handle(EditCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.EditCategoryDto.CategoryId);
            if (category == null) { return EditCategoryResult.NotFound; }

            if (await _categoryRepository.CheckUrlNameCategoriesAsync(request.EditCategoryDto.UrlName,request.EditCategoryDto.CategoryId))
            {
                return EditCategoryResult.IsExistUrlName;
            }
            //category.Id = request.EditCategoryDto.CategoryId;
            category.UrlName = request.EditCategoryDto.UrlName;
            category.Title= request.EditCategoryDto.Title;
            if(request.Image!=null && request.Image.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(request.Image.FileName);
                request.Image.AddImageToServer(imageName, PathExtensions.CategoryOrginServer, 150, 150, PathExtensions.CategoryThumbServer);
                category.ImageName = imageName;
            }
            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return EditCategoryResult.Success;
        }
    }
}
