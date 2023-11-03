using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.OrderEntities.Order.Requests.Queries;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["ResultOrder"] = await _mediator.Send(new GetResaultOrderRequest() { });
            return View();
        }
    }
}
