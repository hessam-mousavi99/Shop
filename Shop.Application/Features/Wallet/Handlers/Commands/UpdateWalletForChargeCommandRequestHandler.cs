using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contracts.Persistence.IRepositories.IWallets;
using Shop.Application.DTOs.Wallet;
using Shop.Application.Features.Wallet.Requests.Commands;
using Shop.Domain.Models.Wallet;

namespace Shop.Application.Features.Wallet.Handlers.Commands
{
    public class UpdateWalletForChargeCommandRequestHandler : IRequestHandler<UpdateWalletForChargeCommandRequest>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public UpdateWalletForChargeCommandRequestHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateWalletForChargeCommandRequest request, CancellationToken cancellationToken)
        {
            var finalwallet = await _walletRepository.GetAsync(request.WalletDto.Id);
            if (request.WalletDto != null)
            {
                request.WalletDto.IsPay = true;
                _mapper.Map(request.WalletDto, finalwallet);
                await _walletRepository.UpdateAsync(finalwallet);
                await _walletRepository.SaveChangesAsync();
            }
            return Unit.Value;
       
        }
    }
}
