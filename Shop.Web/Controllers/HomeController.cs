using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;
using System.Diagnostics;

namespace Shop.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}