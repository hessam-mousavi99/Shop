using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.DTOs.Admin.Order;
using Shop.Application.Features.OrderEntities.Order.Requests.Queries;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Queries
{
    public class GetResaultOrderRequestHandler : IRequestHandler<GetResaultOrderRequest, OrderStateResaultDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetResaultOrderRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderStateResaultDto> Handle(GetResaultOrderRequest request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetResultOrder();
        }
    }
}
