using MediatR;
using Shop.Application.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Account.Users.Requests.Queries
{
    public class GetUserByPhoneNumRequest:IRequest<UserDto>
    {
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
