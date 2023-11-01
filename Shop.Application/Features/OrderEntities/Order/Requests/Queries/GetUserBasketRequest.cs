using MediatR;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Queries
{
    public class GetUserBasketRequest:IRequest<Shop.Domain.Models.OrderEntities.Order>
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
    }
}
