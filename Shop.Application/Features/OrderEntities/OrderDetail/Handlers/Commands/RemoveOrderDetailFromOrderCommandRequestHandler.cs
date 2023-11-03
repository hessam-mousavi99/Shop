using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Features.OrderEntities.OrderDetail.Requests.Commands;

namespace Shop.Application.Features.OrderEntities.OrderDetail.Handlers.Commands
{
    public class RemoveOrderDetailFromOrderCommandRequestHandler : IRequestHandler<RemoveOrderDetailFromOrderCommandRequest, bool>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;

        public RemoveOrderDetailFromOrderCommandRequestHandler(IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
        }
        public async Task<bool> Handle(RemoveOrderDetailFromOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepository.GetAsync(request.OrderDetailId);
            var order = await _orderRepository.GetAsync(orderDetail.OrderId);

            if (orderDetail != null)
            {

                order.OrderSum = (await _orderDetailRepository.OrderSumAsync(orderDetail.OrderId)) - (orderDetail.Price * orderDetail.Count);
                orderDetail.IsDelete = true;
                await _orderDetailRepository.UpdateAsync(orderDetail);
                await _orderRepository.UpdateAsync(order);
                return true;
            }
            return false;
        }
    }
}
