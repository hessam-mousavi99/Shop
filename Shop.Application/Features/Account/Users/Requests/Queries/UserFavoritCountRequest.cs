using MediatR;

namespace Shop.Application.Features.Account.Users.Requests.Queries
{
    public class UserFavoritCountRequest:IRequest<int>
    {
        public long UserId { get; set; }
    }
}
