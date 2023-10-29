using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Extentions;
using Shop.Application.Features.Product.Product.Requests.Commands;
using Shop.Application.Utils;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Product.Product.Handlers.Commands
{
    public class EditProductCommandRequestHandler : IRequestHandler<EditProductCommandRequest, EditProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public EditProductCommandRequestHandler(IProductRepository productRepository,IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public async Task<EditProductResult> Handle(EditProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.EditProductDto.Id);
            if (product == null) { return EditProductResult.NotFound; }
            if (request.EditProductDto.ProductSelectedCategory == null) { return EditProductResult.NotProductSelectedCategoryHasNull; }
            product.ShortDescription = request.EditProductDto.ShortDescription;
            product.Description = request.EditProductDto.Description;
            product.Name= request.EditProductDto.Name;
            product.Price= request.EditProductDto.Price;
            product.IsActive= request.EditProductDto.IsActive;
            if(request.EditProductDto.ProductImage!=null && request.EditProductDto.ProductImage.IsImage())
            {
                var imageName=Guid.NewGuid().ToString("N")+Path.GetExtension(request.EditProductDto.ProductImage.FileName);
                request.EditProductDto.ProductImage.AddImageToServer(imageName,
                    PathExtensions.ProductOrginServer, 255, 255,
                    PathExtensions.ProductThumbServer, product.ProductImageName);
                product.ProductImageName = imageName;
            }

            await _productRepository.UpdateAsync(product);
            await _productCategoryRepository.RemoveProductSelectedCategoryAsync(product.Id);
            await _productCategoryRepository.addProductSelectedCategoryAsync(request.EditProductDto.ProductSelectedCategory,product.Id);
            return EditProductResult.Success;
           

            
        }
    }
}
