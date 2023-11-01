using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Features.OrderEntities.Order.Requests.Queries;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Queries
{
    public class GetUserBasketRequestHandler : IRequestHandler<GetUserBasketRequest, Shop.Domain.Models.OrderEntities.Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetUserBasketRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Domain.Models.OrderEntities.Order> Handle(GetUserBasketRequest request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetUserBasketAsync(request.OrderId, request.UserId);
        }
    }
}
