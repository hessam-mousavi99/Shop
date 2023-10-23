using MediatR;
using Shop.Application.DTOs.Wallet;

namespace Shop.Application.Features.Wallet.Requests.Commands
{
    public class UpdateWalletForChargeCommandRequest:IRequest
    {
        public WalletDto WalletDto { get; set; }
    }
}
