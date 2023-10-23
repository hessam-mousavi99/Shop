using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Extentions;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Application.Features.Account.Users.Requests.Queries;
using Shop.Domain.Enums;
using Shop.Web.Models.VM.Account;

namespace Shop.Web.Areas.User.Controllers
{
    public class AccountController : UserBaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region EditUserProfile
        [HttpGet("edit-profile")]
        public async Task<IActionResult> EditUserProfile()
        {
            var user = await _mediator.Send(new GetEditUserProfileRequest() { Id = User.GetUserId() });
            var mapUser = _mapper.Map<EditUserProfileVM>(user);
            if (mapUser == null)
            {
                return NotFound();
            }
            return View(mapUser);
        }
        [HttpPost("edit-profile")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserProfile(EditUserProfileVM editUserProfileVM,IFormFile userAvatar )
        {
            var editUser = _mapper.Map<EditUserProfileDto>(editUserProfileVM);
            if (ModelState.IsValid)
            {
                var command = new EditUserProfileCommandRequest() { Id=User.GetUserId(),UserAvatar=userAvatar,EditUserProfileDto=editUser };
                var response = await _mediator.Send(command);
                switch (response)
                {
                    case EditUserProfileResult.NotFound:
                        TempData[WarningMessage] = "کاربری با مشخصات وارد شده یافت نشد";
                        break;
                    case EditUserProfileResult.Success:
                        TempData[SuccessMessage] = "عملیات ویرایش حساب کاربری با موفقیت انجام شد";
                        return RedirectToAction("EditUserProfile");
                }
            }
            return View(editUserProfileVM);
        }
        #endregion

        #region Change Password
        [HttpGet("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost("change-password")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM changePasswordVM)
        {
            var changePassMap = _mapper.Map<ChangePasswordDto>(changePasswordVM);
            if (ModelState.IsValid)
            {
                var command = new ChangePasswordCommandRequest() { Id = User.GetUserId(), ChangePasswordDto = changePassMap };
                var response=await _mediator.Send(command);
                switch (response)
                {
                    case ChangePasswordResult.NotFound:
                        TempData[WarningMessage] = "کاربری با مشخصات وارد شده یافت نشد";
                        break;
                    case ChangePasswordResult.PasswordEqual:
                        TempData[InfoMessage] = "لطفا از کلمه عبور جدیدی استفاده کنید";
                        ModelState.AddModelError("NewPassword", "لطفا از کلمه عبور جدیدی استفاده کنید");
                        break;
                    case ChangePasswordResult.Success:
                        TempData[SuccessMessage] = "کلمه ی عبور شما با موفقیت تغیر یافت";
                        TempData[InfoMessage] = "لطفا جهت تکمیل فراید تغیر کلمه ی عبور ،مجددا وارد سایت شود";
                        await HttpContext.SignOutAsync();
                        return RedirectToAction("Login", "Account", new { area = "" });
                }
            }
            return View(changePasswordVM);
        }
        #endregion

    }
}
