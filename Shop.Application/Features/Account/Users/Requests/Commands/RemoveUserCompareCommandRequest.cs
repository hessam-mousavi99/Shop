using MediatR;

namespace Shop.Application.Features.Account.Users.Requests.Commands
{
    public class RemoveUserCompareCommandRequest:IRequest<bool>
    {
        public long Id { get; set; }
    }
}
