﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Account.Users.Requests.Commands
{
    public class IsUserExistsCommandRequest:IRequest<bool>
    {
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
