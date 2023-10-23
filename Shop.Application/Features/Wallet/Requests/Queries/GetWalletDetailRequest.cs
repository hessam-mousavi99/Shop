using MediatR;
using Shop.Application.DTOs.Wallet;

namespace Shop.Application.Features.Wallet.Requests.Queries
{
    public  class GetWalletDetailRequest:IRequest<WalletDto>
    {
        public long Id { get; set; }
    }
}
