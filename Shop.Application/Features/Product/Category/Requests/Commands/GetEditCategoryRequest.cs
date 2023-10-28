using MediatR;
using Shop.Application.DTOs.Admin.Product;

namespace Shop.Application.Features.Product.Category.Requests.Commands
{
    public class GetEditCategoryRequest:IRequest<EditCategoryDto>
    {
        public long CategoryId { get; set; }
    }
}
