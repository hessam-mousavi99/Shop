using MediatR;

namespace Shop.Application.Features.Account.Users.Requests.Commands
{
    public class RemoveAllUserComparesCommandRequest:IRequest<bool>
    {
        public long UserId { get; set; }
    }
}
