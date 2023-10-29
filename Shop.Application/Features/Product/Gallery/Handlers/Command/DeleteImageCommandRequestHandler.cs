using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Features.Product.Gallery.Requests.Command;

namespace Shop.Application.Features.Product.Gallery.Handlers.Command
{
    public class DeleteImageCommandRequestHandler : IRequestHandler<DeleteImageCommandRequest,bool>
    {
        private readonly IProductGalleryRepository _productGalleryRepository;

        public DeleteImageCommandRequestHandler(IProductGalleryRepository productGalleryRepository)
        {
            _productGalleryRepository = productGalleryRepository;
        }
        public async Task<bool> Handle(DeleteImageCommandRequest request, CancellationToken cancellationToken)
        {
            var gallery = await _productGalleryRepository.GetAsync(request.Id);
            if (gallery == null) { return false; }
            gallery.IsDelete = true;
            //UploadImageExtension.DeleteImage(gallery.ImageName, PathExtensions.ProductOrginServer,
            //PathExtensions.ProductThumbServer);
            await _productGalleryRepository.UpdateAsync(gallery);
          
            return true;
        }
    }
}
