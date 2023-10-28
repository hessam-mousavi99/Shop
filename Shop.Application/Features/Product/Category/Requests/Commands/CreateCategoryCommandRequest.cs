using MediatR;
using Microsoft.AspNetCore.Http;
using Shop.Application.DTOs.Admin.Product;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Product.Category.Requests.Commands
{
    public class CreateCategoryCommandRequest:IRequest<CreateCategoryResult>
    {
        public IFormFile? Image { get; set; }
        public CreateCategoryDto? CreateCategoryDto { get; set; }
    }
}
