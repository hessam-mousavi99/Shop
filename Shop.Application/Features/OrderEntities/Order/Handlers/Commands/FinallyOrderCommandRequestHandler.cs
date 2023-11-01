using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.Contracts.Persistence.IRepositories.IWallets;
using Shop.Application.Features.OrderEntities.Order.Requests.Commands;
using Shop.Application.Features.Wallet.Requests.Queries;
using Shop.Domain.Enums;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.Wallet;

namespace Shop.Application.Features.OrderEntities.Order.Handlers.Commands
{
    public class FinallyOrderCommandRequestHandler : IRequestHandler<FinallyOrderCommandRequest, FinallyOrderResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IMediator _mediator;

        public FinallyOrderCommandRequestHandler(IOrderRepository orderRepository, IWalletRepository walletRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _walletRepository = walletRepository;
            _mediator = mediator;
        }
        public async Task<FinallyOrderResult> Handle(FinallyOrderCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.UserId != request.FinalyOrderDto.UserId)
            {
                return FinallyOrderResult.HasNotUser;
            }


            var order = await _orderRepository.GetOrderByIdAsync(request.FinalyOrderDto.OrderId, request.UserId);
            if (order == null || order.IsFinaly == true)
            {
                return FinallyOrderResult.NotFound;
            }

            if (await _mediator.Send(new GetUserWalletAmountRequest() { UserId = request.UserId }) >= order.OrderSum)
            {
                order.IsFinaly = true;
                order.OrderState = OrderState.Requested;


                var wallet = new UserWallet
                {
                    Amount = order.OrderSum,
                    Description = $"فاکتور شماره {order.Id}",
                    IsPay = true,
                    WalletType = WalletType.Bardasht,
                    UserId = request.UserId
                };

                await _walletRepository.AddAsync(wallet);

                await _orderRepository.UpdateAsync(order);

                return FinallyOrderResult.Suceess;
            }

            return FinallyOrderResult.Error;

        }
    }
}
