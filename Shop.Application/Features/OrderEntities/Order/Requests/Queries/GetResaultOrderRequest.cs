using MediatR;
using Shop.Application.DTOs.Admin.Order;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Queries
{
    public class GetResaultOrderRequest:IRequest<OrderStateResaultDto>
    {
    }
}
