using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Features.Product.Comment.Requests.Commands;
using Shop.Domain.Enums;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Features.Product.Comment.Handlers.Commands
{
    public class CreateProductCommentCommandRequestHandler : IRequestHandler<CreateProductCommentCommandRequest, CreateProductCommentResult>
    {
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public CreateProductCommentCommandRequestHandler(IProductCommentRepository productCommentRepository,IProductRepository productRepository,IUserRepository userRepository)
        {
            _productCommentRepository = productCommentRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }
        public async Task<CreateProductCommentResult> Handle(CreateProductCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            if (user == null) { return CreateProductCommentResult.CheckUser; }
            if(!await _productRepository.CheckProductExist(request.CreateProductCommentDto.ProductId))
            {
                return CreateProductCommentResult.CheckProduct;
            }
            var newComment = new ProductComment()
            {
                ProductId = request.CreateProductCommentDto.ProductId,
                Text = request.CreateProductCommentDto.Text,
                UserId = request.UserId,
            };
            await _productCommentRepository.AddAsync(newComment);
            return CreateProductCommentResult.Success;
        }
    }
}
