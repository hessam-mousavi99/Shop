using MediatR;
using Shop.Application.DTOs.Wallet;

namespace Shop.Application.Features.Wallet.Requests.Commands
{
    public class ChargeWalletCommandRequest : IRequest<long>
    {
        public long UserId { get; set; }
        public ChargeWalletDto ChargeWalletDto { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
