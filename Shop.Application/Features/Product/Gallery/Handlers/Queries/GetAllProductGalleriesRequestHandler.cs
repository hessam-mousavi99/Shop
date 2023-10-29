using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Features.Product.Gallery.Requests.Queries;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Features.Product.Gallery.Handlers.Queries
{
    public class GetAllProductGalleriesRequestHandler : IRequestHandler<GetAllProductGalleriesRequest, List<ProductGallery>>
    {
        private readonly IProductGalleryRepository _productGalleryRepository;

        public GetAllProductGalleriesRequestHandler(IProductGalleryRepository productGalleryRepository)
        {
            _productGalleryRepository = productGalleryRepository;
        }
        public async Task<List<ProductGallery>> Handle(GetAllProductGalleriesRequest request, CancellationToken cancellationToken)
        {
            return await _productGalleryRepository.GetProductGalleriesAsync(request.Id); 
        }
    }
}
