using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IWallets;
using Shop.Application.Features.Wallet.Requests.Queries;

namespace Shop.Application.Features.Wallet.Handlers.Queries
{
    public class GetUserWalletAmountRequestHandler : IRequestHandler<GetUserWalletAmountRequest, int>
    {
        private readonly IWalletRepository _walletRepository;

        public GetUserWalletAmountRequestHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public async Task<int> Handle(GetUserWalletAmountRequest request, CancellationToken cancellationToken)
        {
            return await _walletRepository.GetUserWalletAmountAsync(request.UserId);
        }
    }
}
