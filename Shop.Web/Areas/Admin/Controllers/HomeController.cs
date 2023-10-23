using Microsoft.AspNetCore.Mvc;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
