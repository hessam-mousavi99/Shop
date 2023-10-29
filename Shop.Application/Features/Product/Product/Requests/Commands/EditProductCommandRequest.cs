using MediatR;
using Shop.Application.DTOs.Admin.Product;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Product.Product.Requests.Commands
{
    public class EditProductCommandRequest:IRequest<EditProductResult>
    {
        public EditProductDto EditProductDto { get; set; }
    }
}
