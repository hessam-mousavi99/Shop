using MediatR;
using Microsoft.AspNetCore.Http;
using Shop.Application.DTOs.Admin.Product;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Product.Category.Requests.Commands
{
    public class EditCategoryCommandRequest:IRequest<EditCategoryResult>
    {
        public IFormFile? Image { get; set; }
        public EditCategoryDto? EditCategoryDto { get; set; }
    }
}
