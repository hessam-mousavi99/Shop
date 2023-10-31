using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contracts.Infrastructure.IServices;

namespace Shop.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISiteSettingService _siteSettingService;

        public HomeController(ISiteSettingService siteSettingService)
        {
            _siteSettingService = siteSettingService;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["LastProducts"] = await _siteSettingService.LastProducts();
            return View();
        }
    }
}