using MediatR;
using Shop.Application.DTOs.Site;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Product.Comment.Requests.Commands
{
    public class CreateProductCommentCommandRequest:IRequest<CreateProductCommentResult>
    {
        public long UserId { get; set; }
        public CreateProductCommentDto  CreateProductCommentDto { get; set; }
    }
}
