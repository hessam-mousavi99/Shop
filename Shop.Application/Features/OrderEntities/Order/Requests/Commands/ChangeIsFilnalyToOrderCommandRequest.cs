using MediatR;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Commands
{
    public class ChangeIsFilnalyToOrderCommandRequest:IRequest
    {
        public long  OrderId { get; set; }
    }
}
