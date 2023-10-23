using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Contracts.Persistence.IRepositories.IWallets;
using Shop.Application.DTOs.Wallet;
using Shop.Application.Features.Wallet.Requests.Commands;
using Shop.Domain.Enums;
using Shop.Domain.Models.Wallet;

namespace Shop.Application.Features.Wallet.Handlers.Commands
{
    public class ChargeWalletCommandRequestHandler : IRequestHandler<ChargeWalletCommandRequest, long>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ChargeWalletCommandRequestHandler(IWalletRepository walletRepository, IUserRepository userRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<long> Handle(ChargeWalletCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            if (user == null) { return 0; }
            var wallet = new UserWallet();
            wallet.UserId = request.UserId;
            wallet.Amount = request.ChargeWalletDto.Amount;
            wallet.Description = request.Description;
            wallet.IsPay = false;
            wallet.WalletType = WalletType.Variz;
            await _walletRepository.AddAsync(wallet);
            await _walletRepository.SaveChangesAsync();
            return wallet.Id;
        }
    }
}
