using MediatR;
using Shop.Application.DTOs.Site;

namespace Shop.Application.Features.Product.Product.Requests.Queries
{
    public class GetRelatedProductRequest:IRequest<List<ProductItemDto>>
    {
        public string CategoryName { get; set; }
        public long ProductId { get; set; }
    }
}
