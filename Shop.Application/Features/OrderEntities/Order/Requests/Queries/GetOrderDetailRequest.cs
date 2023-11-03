using MediatR;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Queries
{
    public class GetOrderDetailRequest:IRequest<Shop.Domain.Models.OrderEntities.Order>
    {
        public long OrderId { get; set; }
    }
}
