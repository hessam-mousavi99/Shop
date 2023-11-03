using MediatR;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Queries
{
    public class GetUserBasketByUserIdRequest:IRequest<Shop.Domain.Models.OrderEntities.Order>
    {
        public long UserId { get; set; }
    }
}
