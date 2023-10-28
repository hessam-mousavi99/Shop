using MediatR;
using Shop.Application.DTOs.Admin.Product;

namespace Shop.Application.Features.Product.Product.Requests.Queries
{
    public class FilterProductsRequest : IRequest<FilterProductsDto>
    {
        public FilterProductsDto filterProductsDto { get; set; }
    }
}
