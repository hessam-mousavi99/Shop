using MediatR;
using Microsoft.AspNetCore.Http;
using Shop.Application.DTOs.Admin.Product;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Product.Product.Requests.Commands
{
    public class CreateProductCommandRequest : IRequest<CreateProductResult>
    {
        public IFormFile Image { get; set; }
        public CreateProductDto CreateProductDto { get; set; }
    }
}
