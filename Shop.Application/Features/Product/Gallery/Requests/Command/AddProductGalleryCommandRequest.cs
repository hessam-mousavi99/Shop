using MediatR;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Features.Product.Gallery.Requests.Command
{
    public class AddProductGalleryCommandRequest:IRequest<bool>
    {
        public long Id { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
