using MediatR;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Features.Product.Comment.Requests.Queries
{
    public class GetAllCommentsByIdRequest :IRequest<List<ProductComment>>
    {
        public long ProductId { get; set; }
    }
}
