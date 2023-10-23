using MediatR;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Users.Requests.Commands
{
    public class LoginUserCommandRequest:IRequest<LoginUserResult>
    {
        public LoginDto? LoginDto { get; set; }
    }
}
