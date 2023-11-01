using MediatR;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Commands
{
    public class UpdateOrderSumCommandRequest:IRequest
    {
        public long OrderId { get; set; }
    }
}
