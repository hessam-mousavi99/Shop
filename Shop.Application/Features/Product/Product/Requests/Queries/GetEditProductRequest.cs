using MediatR;
using Shop.Application.DTOs.Admin.Product;

namespace Shop.Application.Features.Product.Product.Requests.Queries
{
    public class GetEditProductRequest:IRequest<EditProductDto>
    {
        public long Id { get; set; }
    }
}
