using MediatR;
using Shop.Domain.Models.Account;

namespace Shop.Application.Features.Account.Roles.Requests.Queries
{
    public class GetAllRolesRequest:IRequest<List<Role>>
    {
    }
}
