using MediatR;
using Shop.Domain.Models.Account;

namespace Shop.Application.Features.Account.Permissions.Requests.Queries
{
    public class GetAllActivePermissionsRequest:IRequest<List<Permission>>
    {

    }
}
