using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
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

        public AccountController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            var registerUser = _mapper.Map<CreateUserDto>(register);
            if (ModelState.IsValid)
            {
                var command = new CreateUserRequest { CreateUserDto = registerUser };
                var response = await _mediator.Send(command);
                switch (response)
                {
                    case RegisterUserResult.MobileExists:
                        TempData[ErrorMessage] = "";
                        break;
                    case RegisterUserResult.Success:

                        break;

                }

            }
            return View(register);
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm login)
        {
            var loginUser = _mapper.Map<LoginDto>(login);
            if (ModelState.IsValid)
            {
                var command = new LoginUserCommandRequest { LoginDto = loginUser };
                var response = await _mediator.Send(command);
                switch (response)
                {
                    case LoginUserResult.Success:
                        break;
                    case LoginUserResult.NotActive:
                        break;
                    case LoginUserResult.IsBlocked:
                        break;
                    case LoginUserResult.NotFound:
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
                        return RedirectToAction("Index", "Home");
                        break;

                }

            }
            return View(login);
        }
    }
}
