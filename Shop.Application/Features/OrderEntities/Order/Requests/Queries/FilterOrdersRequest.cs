using MediatR;
using Shop.Application.DTOs.Accounts;

namespace Shop.Application.Features.OrderEntities.Order.Requests.Queries
{
    public class FilterOrdersRequest:IRequest<FilterOrdersDto>
    {
        public FilterOrdersDto FilterOrdersDto { get; set; }
    }
}
