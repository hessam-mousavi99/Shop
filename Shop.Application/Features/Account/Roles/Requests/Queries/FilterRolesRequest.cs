using MediatR;
using Shop.Application.DTOs.Admin.Account;

namespace Shop.Application.Features.Account.Roles.Requests.Queries
{
    public class FilterRolesRequest:IRequest<FilterRolesDto>
    {
        public FilterRolesDto FilterRolesDto { get; set; }
    }
}
