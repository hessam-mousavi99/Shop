using MediatR;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Commands
{
    public class ChangeStateToSentCommandRequest:IRequest<bool>
    {
        public long OrderId { get; set; }
    }
}
