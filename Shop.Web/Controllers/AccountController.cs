using AutoMapper;
using GoogleReCaptcha.V3.Interface;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Application.Features.Account.Users.Requests.Queries;
using Shop.Web.VM.Account;
using System.Security.Claims;

namespace Shop.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ICaptchaValidator _captchaValidator;
    
        public AccountController(IMediator mediator, IMapper mapper,ICaptchaValidator captchaValidator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _captchaValidator = captchaValidator;
        }

        #region Register
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(register.Token))
            {
                TempData[ErrorMessage] = "کد کپچا معتبر نیست";
                return View(register);
            }

            var registerUser = _mapper.Map<CreateUserDto>(register);
            if (ModelState.IsValid)
            {
                var command = new CreateUserRequest { CreateUserDto = registerUser };
                var response = await _mediator.Send(command);
                switch (response)
                {
                    case RegisterUserResult.MobileExists:
                        TempData[ErrorMessage] = "شماره تلفن وارد شده در سیستم از قبل موجود است!!!";
                        break;
                    case RegisterUserResult.Success:
                        TempData[SuccessMessage] = "ثبت نام با موفقیت انجام شد.";
                        return Redirect("/");
                }

            }
            return View(register);
        }

        #endregion

        #region Login
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm login)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(login.Token))
            {
                TempData[ErrorMessage] = "کد کپچا معتبر نیست";
                return View(login);
            }

            var loginUser = _mapper.Map<LoginDto>(login);
            if (ModelState.IsValid)
            {
                var command = new LoginUserCommandRequest { LoginDto = loginUser };
                var response = await _mediator.Send(command);
                switch (response)
                {
                    case LoginUserResult.NotFound:
                        TempData[WarningMessage] = "کاربری یافت نشد.";
                        break;
                    case LoginUserResult.NotActive:
                        TempData[ErrorMessage] = "حساب کاربری شما فعال نمیباشد.";
                        break;
                    case LoginUserResult.IsBlocked:
                        TempData[WarningMessage] = "حساب کاربری شما مسدود است.";
                        TempData[InfoMessage] = "جهت اطلاعات بیشتر به قسمت تماس با ما مراجعه کنید.";
                        break;
                    case LoginUserResult.Success:
                        var user = await _mediator.Send(new GetUserByPhoneNumRequest { PhoneNumber = loginUser.PhoneNumber });
                        var claim = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name,user.PhoneNumber),
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                        };
                        var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = loginUser.RememberMe
                        };
                        await HttpContext.SignInAsync(principal, properties);
                        TempData[SuccessMessage] = "ورود شما با موفقیت انجام شد.";
                        return RedirectToAction("Index", "Home");
                }
            }
            return View(login);
        }
        #endregion

        #region Logout
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            TempData[ErrorMessage] = "شما با موفقیت خارج شدید.";
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
