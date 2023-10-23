using MediatR;
using Microsoft.AspNetCore.Http;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Users.Requests.Commands
{
    public class EditUserProfileCommandRequest:IRequest<EditUserProfileResult>
    {
        public long Id { get; set; }
        public IFormFile UserAvatar { get; set; }
        public EditUserProfileDto EditUserProfileDto { get; set; }
    }
}
