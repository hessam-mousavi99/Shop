using MediatR;
using Shop.Application.DTOs.Admin.Account;

namespace Shop.Application.Features.Account.Roles.Requests.Queries
{
    public class GetRoleRequest : IRequest<CreateOrEditRoleDto>
    {
        public long Id { get; set; }
    }
}
