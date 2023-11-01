using MediatR;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Commands
{
    public class AddOrderCommandRequest:IRequest<long>
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
    }
}
