using MediatR;
using Shop.Application.DTOs.Admin.Account;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Users.Requests.Commands
{
    public class EditUserFromAdminCommandRequest:IRequest<EditUserFromAdminResult>
    {
        public EditUserFromAdminDto EditUserFromAdminDto { get; set; }
    }
}
