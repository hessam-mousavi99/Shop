using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Features.OrderEntities.Order.Requests.Queries;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Queries
{
    public class GetOrderRequestHandler : IRequestHandler<GetOrderRequest, Shop.Domain.Models.OrderEntities.Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Domain.Models.OrderEntities.Order> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAsync(request.OrderId);
        }
    }
}
