using MediatR;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Users.Requests.Commands
{
    public class ActiveAccountCommandRequest:IRequest<ActiveAccountResult>
    {
        public ActiveAccountDto?  activeAccountDto{ get; set; }
       
    }
}
