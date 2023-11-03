using MediatR;
using Shop.Domain.Models.Account;

namespace Shop.Application.Features.Account.Users.Requests.Queries
{
    public class GetUserComparesRequest : IRequest<List<UserCompare>>
    {
        public long UserId { get; set; }
    }
}
