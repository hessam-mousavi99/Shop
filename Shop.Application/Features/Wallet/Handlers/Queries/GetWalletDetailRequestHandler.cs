using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IWallets;
using Shop.Application.DTOs.Wallet;
using Shop.Application.Features.Wallet.Requests.Queries;

namespace Shop.Application.Features.Wallet.Handlers.Queries
{
    public class GetWalletDetailRequestHandler : IRequestHandler<GetWalletDetailRequest, WalletDto>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public GetWalletDetailRequestHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        public async Task<WalletDto> Handle(GetWalletDetailRequest request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetAsync(request.Id);
            return _mapper.Map<WalletDto>(wallet);
        }
    }
}
