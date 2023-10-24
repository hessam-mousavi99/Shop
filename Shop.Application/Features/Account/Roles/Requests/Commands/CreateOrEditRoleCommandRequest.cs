using MediatR;
using Shop.Application.DTOs.Admin.Account;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Roles.Requests.Commands
{
    public class CreateOrEditRoleCommandRequest:IRequest<CreateOrEditRoleResult>
    {
        public CreateOrEditRoleDto? CreateOrEditRoleDto { get; set; }
    }
}
