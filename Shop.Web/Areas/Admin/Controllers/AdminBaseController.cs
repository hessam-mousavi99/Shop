using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminBaseController : Controller
    {
        protected string ErrorMessage = "ErrorMessage";
        protected string SuccessMessage = "SuccessMessage";
        protected string WarningMessage = "WarningMessage";
        protected string InfoMessage = "InfoMessage";
    }
}
