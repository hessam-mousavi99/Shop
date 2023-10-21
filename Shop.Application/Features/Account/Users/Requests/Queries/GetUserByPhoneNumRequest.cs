using MediatR;
using Shop.Application.DTOs.Accounts;

namespace Shop.Application.Features.Account.Users.Requests.Queries
{
    public class GetUserByPhoneNumRequest:IRequest<UserDto>
    {
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
