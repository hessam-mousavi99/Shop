using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Extentions;
using Shop.Application.Features.Product.Category.Requests.Commands;
using Shop.Application.Utils;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Product.Category.Handlers.Commands
{
    public class CreateCategoryCommandRequestHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CreateCategoryResult> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _categoryRepository.CheckUrlNameCategoriesAsync(request.CreateCategoryDto.UrlName))
            {
                return CreateCategoryResult.IsExistUrlName;
            }
            var newCategory = new Shop.Domain.Models.ProductEntities.Category()
            {
                UrlName= request.CreateCategoryDto.UrlName,
                Title=request.CreateCategoryDto.Title,
                ParentId=null,    
            };
            if (request.Image!=null && request.Image.IsImage() )
            {
                var imageName=Guid.NewGuid().ToString("N")+Path.GetExtension(request.Image.FileName);
                request.Image.AddImageToServer(imageName, PathExtensions.CategoryOrginServer, 150, 150, PathExtensions.CategoryThumbServer);
                newCategory.ImageName = imageName;
            }
            await _categoryRepository.AddAsync(newCategory);
            await _categoryRepository.SaveChangesAsync();
            return CreateCategoryResult.Success;
        }
    }
}
