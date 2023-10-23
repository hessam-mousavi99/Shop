using MediatR;
using Shop.Application.DTOs.Admin.Account;

namespace Shop.Application.Features.Account.Users.Requests.Queries
{
    public class FilterUsersRequest:IRequest<FilterUserDto>
    {
        public FilterUserDto FilterUserDto { get; set; }
    }
}
