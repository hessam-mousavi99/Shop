using MediatR;
using Shop.Application.DTOs.Wallet;

namespace Shop.Application.Features.Wallet.Requests.Queries
{
    public class FilterWalletsRequest:IRequest<FilterWalletDto>
    {
        public FilterWalletDto filterWalletDto { get; set; }
    }
}
