using MediatR;

namespace Shop.Application.Features.OrderEntities.OrderDetail.Requests.Commands
{
    public class RemoveOrderDetailFromOrderCommandRequest:IRequest<bool>
    {
        public long OrderDetailId { get; set; }
    }
}
