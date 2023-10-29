using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Extentions;
using Shop.Application.Features.Product.Gallery.Requests.Command;
using Shop.Application.Utils;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Features.Product.Gallery.Handlers.Command
{
    public class AddProductGalleryCommandRequestHandler : IRequestHandler<AddProductGalleryCommandRequest, bool>
    {
        private readonly IProductGalleryRepository _productGalleryRepository;
        private readonly IProductRepository _productRepository;

        public AddProductGalleryCommandRequestHandler(IProductGalleryRepository productGalleryRepository, IProductRepository productRepository)
        {
            _productGalleryRepository = productGalleryRepository;
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(AddProductGalleryCommandRequest request, CancellationToken cancellationToken)
        {
            if (!await _productRepository.CheckProductExist(request.Id))
            {
                return false;
            }

            if (request.Images != null && request.Images.Any())
            {
                var gallery = new List<ProductGallery>();
                foreach (var image in request.Images)
                {
                    if (image.IsImage())
                    {
                        var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(image.FileName);
                        image.AddImageToServer(imageName, PathExtensions.ProductOrginServer, 255, 255, PathExtensions.ProductThumbServer);

                        gallery.Add(new ProductGallery()
                        {
                            ImageName = imageName,
                            ProductId = request.Id
                        });
                    }
                }
                await _productGalleryRepository.AddProductGalleries(gallery);
            }
            return true;
        }
    }
}
