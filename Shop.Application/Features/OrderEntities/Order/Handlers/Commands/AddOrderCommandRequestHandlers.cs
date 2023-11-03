using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Features.OrderEntities.Order.Requests.Commands;
using Shop.Domain.Models.OrderEntities;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Commands
{
    public class AddOrderCommandRequestHandlers : IRequestHandler<AddOrderCommandRequest, long>
    {
        private readonly IMediator _mediator;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public AddOrderCommandRequestHandlers(IMediator mediator, IOrderRepository orderRepository, IProductRepository productRepository,IOrderDetailRepository orderDetailRepository)
        {
            _mediator = mediator;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<long> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.ProductId);
            var order = await _orderRepository.CheckUserOrderAsync(request.UserId);

            if (order.IsFinaly)
            {
                order = new Domain.Models.OrderEntities.Order()
                {
                    UserId = request.UserId,
                    IsFinaly = false,
                    OrderState = Domain.Enums.OrderState.Processing,
                    OrderSum = product.Price,
                    OrderDetails = new List<Shop.Domain.Models.OrderEntities.OrderDetail>()
                    {
                        new Shop.Domain.Models.OrderEntities.OrderDetail()
                        {
                            Price = product.Price,
                            ProductId = request.ProductId,
                            Count=1,
                            
                        }
                    }
                };
                await _orderRepository.AddAsync(order);     
            }
            else
            {
                var detail = await _orderDetailRepository.CheckOrderDetailExistsAsync(order.Id, product.Id);
                if (detail != null)
                {
                    detail.Count ++;
                    await _orderDetailRepository.UpdateAsync(detail);   
                }
                else
                {
                    detail=new Shop.Domain.Models.OrderEntities.OrderDetail()
                    {
                        Count=1,
                        Price=product.Price,
                        ProductId=request.ProductId,
                         OrderId=order.Id,
                    };
                    await _orderDetailRepository.AddAsync(detail);          
                }
            }
            await _mediator.Send(new UpdateOrderSumCommandRequest() { OrderId = order.Id });
            return order.Id;
        }
    }
}
