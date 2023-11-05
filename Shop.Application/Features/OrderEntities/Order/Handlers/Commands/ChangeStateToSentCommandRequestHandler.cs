using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Features.OrderEntities.Order.Requests.Commands;
using Shop.Domain.Enums;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Commands
{
    public class ChangeStateToSentCommandRequestHandler : IRequestHandler<ChangeStateToSentCommandRequest, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeStateToSentCommandRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> Handle(ChangeStateToSentCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);
            if (order == null) { return false; }

            order.OrderState=OrderState.Sent;
            await _orderRepository.UpdateAsync(order);
            return true;
        }
    }
}
