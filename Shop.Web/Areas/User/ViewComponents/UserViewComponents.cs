using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Account.Users.Requests.Queries;
using Shop.Infrastructure.Extentions;
namespace Shop.Web.Areas.User.ViewComponents;

public class UserSideBarViewComponent : ViewComponent
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    #region constrator

    public UserSideBarViewComponent(IMediator mediator,IMapper mapper) 
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _mediator.Send(new GetUserDetailRequest() { Id = User.GetUserId() });
            var map = _mapper.Map<Shop.Domain.Models.Account.User>(user);
            return View("UserSideBar", map);
        }
        return View("UserSideBar");
    }
    #endregion
}

public class UserInformationViewComponent : ViewComponent
{
    #region constrator
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public UserInformationViewComponent(IMediator mediator,IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _mediator.Send(new GetUserDetailRequest() { Id = User.GetUserId() });
            var map = _mapper.Map<Shop.Domain.Models.Account.User>(user);
            return View("UserInformation", map);
        }

        return View("UserInformation");
    }
    #endregion
}
