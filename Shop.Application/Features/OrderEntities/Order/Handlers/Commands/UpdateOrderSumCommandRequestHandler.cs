using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Features.OrderEntities.Order.Requests.Commands;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Commands
{
    public class UpdateOrderSumCommandRequestHandler : IRequestHandler<UpdateOrderSumCommandRequest>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public UpdateOrderSumCommandRequestHandler(IOrderRepository orderRepository,IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<Unit> Handle(UpdateOrderSumCommandRequest request, CancellationToken cancellationToken)
        {
            var  order=await _orderRepository.GetAsync(request.OrderId);
            order.OrderSum=await _orderDetailRepository.OrderSumAsync(request.OrderId);
            await _orderRepository.UpdateAsync(order);
            return Unit.Value;
        }
    }
}
