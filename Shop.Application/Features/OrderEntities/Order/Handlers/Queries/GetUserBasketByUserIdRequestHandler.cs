using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Features.OrderEntities.Order.Requests.Queries;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Queries
{
    public class GetUserBasketByUserIdRequestHandler : IRequestHandler<GetUserBasketByUserIdRequest, Domain.Models.OrderEntities.Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetUserBasketByUserIdRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Domain.Models.OrderEntities.Order> Handle(GetUserBasketByUserIdRequest request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetUserBasketAsync(request.UserId);
        }
    }
}
