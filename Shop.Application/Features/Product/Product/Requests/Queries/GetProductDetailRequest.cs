using MediatR;
using Shop.Application.DTOs.Site;

namespace Shop.Application.Features.Product.Product.Requests.Queries
{
    public class GetProductDetailRequest:IRequest<ProductDetailDto>
    {
        public long ProductId { get; set; }
    }
}
