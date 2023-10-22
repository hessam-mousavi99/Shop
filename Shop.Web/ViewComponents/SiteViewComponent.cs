using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Account.Users.Requests.Queries;
using Shop.Domain.Models.Account;

namespace Shop.Web.ViewComponents
{
    #region Header
    public class SiteHeaderViewComponent:ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SiteHeaderViewComponent(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
               var user= await _mediator.Send(new GetUserByPhoneNumRequest() { PhoneNumber=User.Identity.Name});
                var map = _mapper.Map<User>(user);
                ViewBag.User=map;
            
            }
            return View("SiteHeader");
        }
    }
    #endregion
    #region Footer
    public class SiteFooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteFooter");
        }
    }
    #endregion
}
