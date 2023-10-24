using MediatR;
using Shop.Application.DTOs.Admin.Account;

namespace Shop.Application.Features.Account.Users.Requests.Queries
{
    public class GetUserForEditInAdminRequest:IRequest<EditUserFromAdminDto>
    {
        public long Id { get; set; }
    }
}
