using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IWallets;
using Shop.Application.DTOs.Wallet;
using Shop.Application.Features.Wallet.Requests.Queries;

namespace Shop.Application.Features.Wallet.Handlers.Queries
{
    public class FilterWalletsRequestHandler : IRequestHandler<FilterWalletsRequest, FilterWalletDto>
    {
        private readonly IWalletRepository _walletRepository;

        public FilterWalletsRequestHandler(IWalletRepository walletRepository)
        {
            _walletRepository=walletRepository;
        }
        public async Task<FilterWalletDto> Handle(FilterWalletsRequest request, CancellationToken cancellationToken)
        {
            return await _walletRepository.FilterWallets(request.filterWalletDto);
        }
    }
}
