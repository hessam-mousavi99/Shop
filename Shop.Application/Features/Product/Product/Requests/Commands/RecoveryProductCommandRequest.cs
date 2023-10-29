using MediatR;

namespace Shop.Application.Features.Product.Product.Requests.Commands
{
    public class RecoveryProductCommandRequest : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
