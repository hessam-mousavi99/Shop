using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Application.Contracts.Infrastructure.IServices;

namespace Shop.Application.PermissionCheck
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUserService _userService;
        private long _permissionId = 0;
        public PermissionCheckerAttribute(long permissionId)
        {
            _permissionId = permissionId;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _userService=(IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var phoneNumber = context.HttpContext.User.Identity.Name;
                if (!_userService.CheckPermission(_permissionId, phoneNumber))
                {
                    context.Result = new RedirectToActionResult("Login","Account","login");
                }
            }
            else
            {
                context.Result = new RedirectToActionResult("Login", "Account", "login");
            }

        }
    }
}
