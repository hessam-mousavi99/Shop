using MediatR;

namespace Shop.Application.Features.Product.Product.Requests.Commands
{
    public class AddProductToCompareCommandRequest : IRequest<bool>
    {
        public long ProductId { get; set; }
        public long UserId { get; set; }
    }
}
