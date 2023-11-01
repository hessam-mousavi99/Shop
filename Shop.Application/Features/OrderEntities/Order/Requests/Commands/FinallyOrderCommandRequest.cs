using MediatR;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Enums;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Commands
{
    public class FinallyOrderCommandRequest:IRequest<FinallyOrderResult>
    {
        public FinalyOrderDto   FinalyOrderDto { get; set; }
        public long UserId { get; set; }
    }
}
