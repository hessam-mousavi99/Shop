using MediatR;

namespace Shop.Application.Features.Wallet.Requests.Queries
{
    public class GetUserWalletAmountRequest : IRequest<int>
    {
        public long UserId { get; set; }
    }
}
