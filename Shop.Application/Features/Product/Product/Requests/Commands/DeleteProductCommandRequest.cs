using MediatR;

namespace Shop.Application.Features.Product.Product.Requests.Commands
{
    public class DeleteProductCommandRequest : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
