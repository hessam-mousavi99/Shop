using MediatR;
using Shop.Application.DTOs.Accounts;

namespace Shop.Application.Features.Account.Users.Requests.Queries
{
    public class GetEditUserProfileRequest:IRequest<EditUserProfileDto>
    {
        public long Id { get; set; }
    }
}
