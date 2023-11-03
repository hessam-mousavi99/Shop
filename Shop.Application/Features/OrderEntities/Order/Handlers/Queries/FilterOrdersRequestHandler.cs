using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Features.OrderEntities.Order.Requests.Queries;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Queries
{
    public class FilterOrdersRequestHandler : IRequestHandler<FilterOrdersRequest, FilterOrdersDto>
    {
        private readonly IOrderRepository _orderRepository;

        public FilterOrdersRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<FilterOrdersDto> Handle(FilterOrdersRequest request, CancellationToken cancellationToken)
        {
            return await _orderRepository.FilterOrdersAsync(request.FilterOrdersDto);
        }
    }
}
