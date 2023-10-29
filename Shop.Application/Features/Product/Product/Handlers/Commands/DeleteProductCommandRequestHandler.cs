using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Features.Product.Product.Requests.Commands;

namespace Shop.Application.Features.Product.Product.Handlers.Commands
{
    public class DeleteProductCommandRequestHandler : IRequestHandler<DeleteProductCommandRequest, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.Id);
            if (product == null) { return false; }
            product.IsDelete = true;
            await _productRepository.UpdateAsync(product);
            return true;
        }
    }
}
