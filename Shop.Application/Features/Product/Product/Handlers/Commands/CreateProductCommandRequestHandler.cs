using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Extentions;
using Shop.Application.Features.Product.Product.Requests.Commands;
using Shop.Application.Utils;
using Shop.Domain.Enums;


namespace Shop.Application.Features.Product.Product.Handlers.Commands
{
    public class CreateProductCommandRequestHandler : IRequestHandler<CreateProductCommandRequest, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandRequestHandler(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public async Task<CreateProductResult> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Shop.Domain.Models.ProductEntities.Product>(request.CreateProductDto);
            if (request.Image != null && request.Image.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(request.Image.FileName);
                request.Image.AddImageToServer(imageName, PathExtensions.ProductOrginServer, 255, 255, PathExtensions.ProductThumbServer);
                newProduct.ProductImageName = imageName;
            }
            else
            {
                return CreateProductResult.NotImage;
            }
            await _productRepository.AddAsync(newProduct);
            await _productRepository.SaveChangesAsync();
            await _productCategoryRepository.addProductSelectedCategoryAsync
                (request.CreateProductDto.ProductSelectedCategory, newProduct.Id);
            return CreateProductResult.Success;
        }
    }
}
