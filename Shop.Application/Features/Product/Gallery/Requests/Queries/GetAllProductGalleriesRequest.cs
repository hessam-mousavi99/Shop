using MediatR;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Features.Product.Gallery.Requests.Queries
{
    public class GetAllProductGalleriesRequest:IRequest<List<ProductGallery>>
    {
        public long Id { get; set; }
    }
}
