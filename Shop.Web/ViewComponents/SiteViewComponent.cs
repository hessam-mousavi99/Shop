using Microsoft.AspNetCore.Mvc;

namespace Shop.Web.ViewComponents
{
    #region Header
    public class SiteHeaderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
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
