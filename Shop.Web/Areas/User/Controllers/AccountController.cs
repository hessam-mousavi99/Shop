using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Accounts;
using Shop.Application.DTOs.Wallet;
using Shop.Application.Extentions;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Application.Features.Account.Users.Requests.Queries;
using Shop.Application.Features.OrderEntities.Order.Requests.Commands;
using Shop.Application.Features.OrderEntities.Order.Requests.Queries;
using Shop.Application.Features.OrderEntities.OrderDetail.Requests.Commands;
using Shop.Application.Features.Wallet.Requests.Commands;
using Shop.Application.Features.Wallet.Requests.Queries;
using Shop.Domain.Enums;
using Shop.Domain.Models.Account;
using Shop.Web.Extentions;
using Shop.Web.Models.VM.Account;
using Shop.Web.Models.VM.Wallet;
using ZarinpalSandbox;

namespace Shop.Web.Areas.User.Controllers
{
    public class AccountController : UserBaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountController(IMediator mediator, IMapper mapper, IConfiguration configuration)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configuration = configuration;
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
        public async Task<IActionResult> EditUserProfile(EditUserProfileVM editUserProfileVM, IFormFile userAvatar)
        {
            var editUser = _mapper.Map<EditUserProfileDto>(editUserProfileVM);
            if (ModelState.IsValid)
            {
                var command = new EditUserProfileCommandRequest() { Id = User.GetUserId(), UserAvatar = userAvatar, EditUserProfileDto = editUser };
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
                var response = await _mediator.Send(command);
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

        #region Charge Wallet
        [HttpGet("charge-wallet")]
        public IActionResult ChargeWallet()
        {
            return View();
        }

        [HttpPost("charge-wallet"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ChargeWallet(ChargeWalletVM chargeWalletvm)
        {
            var charge = _mapper.Map<ChargeWalletDto>(chargeWalletvm);
            if (ModelState.IsValid)
            {
                var command = new ChargeWalletCommandRequest() { UserId = User.GetUserId(), ChargeWalletDto = charge, Description = $"شارژ به مبلغ {charge.Amount}" };
                var response = await _mediator.Send(command);
                var walletId = response;

                #region payment
                var payment = new Payment(charge.Amount);
                var url = _configuration.GetSection("DefaultUrl")["Host"] + "/user/online-payment/" + walletId;
                var result = payment.PaymentRequest("شارژ کیف پول", url);

                if (result.Result.Status == 100)
                {

                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Result.Authority);
                }
                else
                {
                    TempData[ErrorMessage] = "مشکلی در پرداخت به وجود آماده است،لطفا مجددا امتحان کنید";
                }

                #endregion
            }
            return View(chargeWalletvm);
        }
        #endregion

        #region Online Payment
        [HttpGet("online-payment/{id}")]
        public async Task<IActionResult> OnlinePayment(long id)
        {
            if (HttpContext.Request.Query["Status"] != "" && HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];
                var wallet = await _mediator.Send(new GetWalletDetailRequest() { Id = id });
                if (wallet != null)
                {
                    var payment = new Payment(wallet.Amount);
                    var result = payment.Verification(authority).Result;

                    if (result.Status == 100)
                    {
                        ViewBag.RefId = result.RefId;
                        ViewBag.Success = true;
                        var command = new UpdateWalletForChargeCommandRequest() { WalletDto = wallet };
                        await _mediator.Send(command);
                    }
                    return View();
                }
                return NotFound();
            }
            return View();
        }
        #endregion

        #region user wallet
        [HttpGet("user-wallet")]
        public async Task<IActionResult> UserWallet(FilterWalletVM filter)
        {
            filter.UserId = User.GetUserId();
            var mapRequest = _mapper.Map<FilterWalletDto>(filter);
            var response = await _mediator.Send(new FilterWalletsRequest() { filterWalletDto = mapRequest });
            var mapResponse = _mapper.Map<FilterWalletVM>(response);
            return View(mapResponse);
        }
        #endregion

        #region user-basket
        [HttpGet("basket/{orderId}")]
        public async Task<IActionResult> UserBasket(long orderId)
        {
            var order = await _mediator.Send(new GetUserBasketRequest() { OrderId = orderId, UserId = User.GetUserId() });
            if (order == null)
            {
                return NotFound();
            }
            ViewBag.UserWalletAmount = await _mediator.Send(new GetUserWalletAmountRequest() { UserId = User.GetUserId() });

            return View(order);
        }

        [HttpPost("basket/{orderId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> UserBasket(FinallyOrderVM finallyOrder)
        {
            var Final = _mapper.Map<FinalyOrderDto>(finallyOrder);
            if (Final.IsWallet)
            {
                var command = new FinallyOrderCommandRequest() { FinalyOrderDto = Final, UserId = User.GetUserId() };
                var response = await _mediator.Send(command);
                switch (response)
                {
                    case FinallyOrderResult.HasNotUser:
                        TempData[ErrorMessage] = "سفارش شما یفت نشد";
                        break;
                    case FinallyOrderResult.NotFound:
                        TempData[ErrorMessage] = "سفارش شما یفت نشد";
                        break;
                    case FinallyOrderResult.Error:
                        TempData[ErrorMessage] = "موجودی کیف پول شما کافی نمیباشد";
                        return RedirectToAction("UserWallet");
                    case FinallyOrderResult.Suceess:
                        TempData[SuccessMessage] = "فاکتور شما با موفقیت پرداخت شد از خرید متشکریم";
                        return RedirectToAction("UserWallet");

                }
            }
            else
            {
                var order = await _mediator.Send(new GetOrderRequest() { OrderId = Final.OrderId });
                #region payment
                var payment = new Payment(order.OrderSum);
                var url = _configuration.GetSection("DefaultUrl")["Host"] + "/user/online-order/" + order.Id;
                var result = payment.PaymentRequest("شارژ کیف پول", url);

                if (result.Result.Status == 100)
                {
                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Result.Authority);
                }
                else
                {
                    TempData[ErrorMessage] = "مشکلی در پرداخت به وجود آماده است،لطفا مجددا امتحان کنید";
                }
                #endregion
            }


            ViewBag.UserWalletAmount = await _mediator.Send(new GetUserWalletAmountRequest() { UserId = Final.UserId });

            return View();
        }

        #endregion

        #region order payment
        [HttpGet("online-order/{id}")]
        public async Task<IActionResult> OrderPayment(long id)
        {
            if (HttpContext.Request.Query["Status"] != "" && HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];
                var order = await _mediator.Send(new GetOrderRequest() { OrderId = id });
                if (order != null)
                {
                    var payment = new Payment(order.OrderSum);
                    var result = payment.Verification(authority).Result;

                    if (result.Status == 100)
                    {
                        ViewBag.RefId = result.RefId;
                        ViewBag.Success = true;
                        var command = new ChangeIsFilnalyToOrderCommandRequest() { OrderId = id };
                        await _mediator.Send(command);
                    }
                    return View();
                }
                return NotFound();
            }
            return View();
        }
        #endregion

        #region user-orders
        [HttpGet("user-orders")]
        public async Task<IActionResult> UserOrders(FilterOrdersVM filterOrdersVM)
        {
            filterOrdersVM.UserId = User.GetUserId();
            var filter = _mapper.Map<FilterOrdersDto>(filterOrdersVM);
            var response = await _mediator.Send(new FilterOrdersRequest() { FilterOrdersDto = filter });
            return View(_mapper.Map<FilterOrdersVM>(response));
        }
        #endregion

        #region reload-price
        [HttpGet("reload-price")]
        public async Task<IActionResult> ReloadOrderPrice(long id)
        {
            var order = await _mediator.Send(new GetUserBasketRequest() { OrderId = id, UserId = User.GetUserId() });
            ViewBag.UserWalletAmount = await _mediator.Send(new GetUserWalletAmountRequest() { UserId = User.GetUserId() });
            return PartialView("_OrderPrice", order);
        }
        #endregion

        #region delete-order-detail
        [HttpGet("delete-orderDetail/{orderDetailId}")]
        public async Task<IActionResult> DeleteOrderDetail(long orderDetailId)
        {
            var command = new RemoveOrderDetailFromOrderCommandRequest() { OrderDetailId= orderDetailId };
            var response=await _mediator.Send(command);
            if (response)
            {
                return JsonResponseStatus.Success();
            }
            return JsonResponseStatus.Error();
        }
        #endregion
    }
}
