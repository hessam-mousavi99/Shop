using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.Features.Account.Permissions.Requests.Queries;
using Shop.Application.Features.Account.Roles.Requests.Commands;
using Shop.Application.Features.Account.Roles.Requests.Queries;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Application.Features.Account.Users.Requests.Queries;
using Shop.Domain.Enums;
using Shop.Web.Models.VM.Admin.Account;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        #region filter user
        public async Task<IActionResult> FilterUser(FilterUserVM filter)
        {
            var mapRequest = _mapper.Map<FilterUserDto>(filter);
            var response = await _mediator.Send(new FilterUsersRequest() { FilterUserDto = mapRequest });
            var mapResponse = _mapper.Map<FilterUserVM>(response);
            return View(mapResponse);
        }
        #endregion

        #region edit user
        [HttpGet]
        public async Task<IActionResult> EditUser(long userId) //id
        {
            var data = await _mediator.Send(new GetUserForEditInAdminRequest() { Id = userId });

            if (data == null)
            {
                return NotFound();
            }

            ViewData["Roles"] = await _mediator.Send(new GetAllRolesRequest());
            return View(_mapper.Map<EditUserFromAdminVM>(data));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserFromAdminVM editUser)
        {
            ViewData["Roles"] = await _mediator.Send(new GetAllRolesRequest());
            var mapUser = _mapper.Map<EditUserFromAdminDto>(editUser);
            
            if (ModelState.IsValid)
            {
                var command = new EditUserFromAdminCommandRequest() { EditUserFromAdminDto=mapUser};
                var response= await _mediator.Send(command);
                switch (response)
                {
                    case EditUserFromAdminResult.NotFound:
                        TempData[WarningMessage] = "کاربری با مشخصات وارد شده یافت نشد";
                        break;
                    case EditUserFromAdminResult.Success:
                        TempData[SuccessMessage] = "ویراش کاربر با موفقیت انجام شد";
                        return RedirectToAction("FilterUser");
                }
            }
            return View(editUser);
        }

        #endregion

        #region filter roles
        public async Task<IActionResult> FilterRoles(FilterRolesVM filter)
        {
            var mapRequest = _mapper.Map<FilterRolesDto>(filter);
            var response = await _mediator.Send(new FilterRolesRequest() { FilterRolesDto = mapRequest });
            var mapResponse = _mapper.Map<FilterRolesVM>(response);
            return View(mapResponse);
        }
        #endregion

        #region create Role
        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(CreateOrEditRoleVM create)
        {
            var mapRoleDto = _mapper.Map<CreateOrEditRoleDto>(create);
            if (ModelState.IsValid)
            {
                var command= new CreateOrEditRoleCommandRequest() { CreateOrEditRoleDto = mapRoleDto };
                var response =await _mediator.Send(command);

                switch (response)
                {
                    case CreateOrEditRoleResult.NotFound:
                        break;
                    case CreateOrEditRoleResult.NotExistPermissions:
                        TempData[WarningMessage] = "لطفا نقشی را انتخاب کنید";
                        break;
                    case CreateOrEditRoleResult.Success:
                        TempData[SuccessMessage] = "عملیات افزودن نقش با موفقیت انجام شد";
                        return RedirectToAction("FilterRoles");
                }
            }
            return View(create);
        }
        #endregion

        #region Edit Role
        [HttpGet]
        public async Task<IActionResult> EditRole(long roleId)
        {
            var role = await _mediator.Send(new GetRoleRequest() { Id = roleId });
            var RoleVM = _mapper.Map<CreateOrEditRoleVM>(role);
            ViewData["Permissions"] = await _mediator.Send(new GetAllActivePermissionsRequest());
            return View(RoleVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(CreateOrEditRoleVM create)
        {
            var mapRoleDto = _mapper.Map<CreateOrEditRoleDto>(create);
            ViewData["Permissions"] = await _mediator.Send(new GetAllActivePermissionsRequest());
            if (ModelState.IsValid)
            {
                var command = new CreateOrEditRoleCommandRequest() { CreateOrEditRoleDto = mapRoleDto };
                var response = await _mediator.Send(command);
                switch (response)
                {
                    case CreateOrEditRoleResult.NotFound:
                        TempData[WarningMessage] = "نقشی با مشخصات وارد شده یافت نشد";
                        break;
                    case CreateOrEditRoleResult.NotExistPermissions:
                        TempData[WarningMessage] = "لطفا نقشی را انتخاب کنید";
                        break;
                    case CreateOrEditRoleResult.Success:
                        TempData[SuccessMessage] = "عملیات ویرایش نقش با موفقیت انجام شد";
                        return RedirectToAction("FilterRoles");
                }
            }
            return View(create);
        }
        #endregion
    }
}
