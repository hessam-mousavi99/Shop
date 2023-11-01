using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Features.OrderEntities.Order.Requests.Queries;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Queries
{
    public class GetOrderByOrderIdAndUserIdRequestHandler : IRequestHandler<GetOrderByOrderIdAndUserIdRequest, Shop.Domain.Models.OrderEntities.Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByOrderIdAndUserIdRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Domain.Models.OrderEntities.Order> Handle(GetOrderByOrderIdAndUserIdRequest request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderByIdAsync(request.OrderId, request.UserId);
        }
    }
}
