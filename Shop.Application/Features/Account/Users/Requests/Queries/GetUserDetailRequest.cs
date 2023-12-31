﻿using MediatR;
using Shop.Application.DTOs.Accounts;

namespace Shop.Application.Features.Account.Users.Requests.Queries
{
    public class GetUserDetailRequest:IRequest<UserDto>
    {
        public long Id { get; set; }
    }
}
