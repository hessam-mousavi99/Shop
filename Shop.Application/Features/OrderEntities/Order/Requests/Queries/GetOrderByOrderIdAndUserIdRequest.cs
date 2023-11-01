using MediatR;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Queries
{
    public class GetOrderByOrderIdAndUserIdRequest : IRequest<Shop.Domain.Models.OrderEntities.Order>
    {
        public long UserId { get; set; }
        public long OrderId { get; set; }
    }
}
