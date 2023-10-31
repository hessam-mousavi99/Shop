

using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Features.Product.Comment.Requests.Queries;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Features.Product.Comment.Handlers.Queries
{
    public class GetAllCommentsByIdRequestHandler : IRequestHandler<GetAllCommentsByIdRequest, List<ProductComment>>
    {
        private readonly IProductCommentRepository _productCommentRepository;

        public GetAllCommentsByIdRequestHandler(IProductCommentRepository productCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
        }
        public async Task<List<ProductComment>> Handle(GetAllCommentsByIdRequest request, CancellationToken cancellationToken)
        {
            return await _productCommentRepository.GetAllCommentsByIdAsync(request.ProductId);
        }
    }
}
