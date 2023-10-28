using MediatR;
using Shop.Application.DTOs.Admin.Product;

namespace Shop.Application.Features.Product.Category.Requests.Queries
{
    public class FilterCategoryRequest:IRequest<FilterCategoryDto>
    {
        public FilterCategoryDto? FilterCategoryDto { get; set; }
    }
}
