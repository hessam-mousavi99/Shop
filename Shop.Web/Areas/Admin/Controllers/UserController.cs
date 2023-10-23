using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.Features.Account.Users.Requests.Queries;
using Shop.Web.Models.VM.Admin.Account;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        #region filter user
        public async Task<IActionResult> FilterUser(FilterUserVM filter)
        {
            var mapRequest = _mapper.Map<FilterUserDto>(filter);
            var response = await _mediator.Send(new FilterUsersRequest() { FilterUserDto = mapRequest });
            var mapResponse = _mapper.Map<FilterUserVM>(response);
            return View(mapResponse);
        }
        #endregion

    }
}
