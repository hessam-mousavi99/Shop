using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Features.OrderEntities.Order.Requests.Queries;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Queries
{
    public class GetOrderDetailRequestHandler : IRequestHandler<GetOrderDetailRequest, Shop.Domain.Models.OrderEntities.Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderDetailRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Domain.Models.OrderEntities.Order> Handle(GetOrderDetailRequest request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderDetailAsync(request.OrderId);
        }
    }
}
