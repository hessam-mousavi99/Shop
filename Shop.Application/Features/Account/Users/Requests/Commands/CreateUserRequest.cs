using MediatR;
using Shop.Application.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Account.Users.Requests.Commands
{
    public class CreateUserRequest:IRequest<RegisterUserResult>
    {
        public CreateUserDto? CreateUserDto { get; set; }
    }
}
