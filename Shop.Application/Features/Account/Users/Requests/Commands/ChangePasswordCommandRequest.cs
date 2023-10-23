using MediatR;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Users.Requests.Commands
{
    public class ChangePasswordCommandRequest:IRequest<ChangePasswordResult>
    {
        public long Id { get; set; }
        public ChangePasswordDto ChangePasswordDto { get; set; }
    }
}
