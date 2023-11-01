using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Features.OrderEntities.Order.Requests.Commands;
using Shop.Domain.Enums;
using Shop.Domain.Models.OrderEntities;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Commands
{
    public class ChangeIsFilnalyToOrderCommandRequestHandler : IRequestHandler<ChangeIsFilnalyToOrderCommandRequest>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeIsFilnalyToOrderCommandRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Unit> Handle(ChangeIsFilnalyToOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);
            order.IsFinaly = true;
            order.OrderState = OrderState.Requested;
            await _orderRepository.UpdateAsync(order);
            return Unit.Value;
        }
    }
}
