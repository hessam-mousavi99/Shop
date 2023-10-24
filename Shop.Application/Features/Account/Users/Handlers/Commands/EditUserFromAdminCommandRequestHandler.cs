using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Users.Handlers.Commands
{
    public class EditUserFromAdminCommandRequestHandler : IRequestHandler<EditUserFromAdminCommandRequest, EditUserFromAdminResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHelper _passwordHelper;
        private readonly IUserRoleRepository _userroleRepository;
        public EditUserFromAdminCommandRequestHandler(IUserRepository userRepository,IUserRoleRepository userRoleRepository,IMapper mapper,IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHelper = passwordHelper;
            _userroleRepository = userRoleRepository;
        }
        public async Task<EditUserFromAdminResult> Handle(EditUserFromAdminCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.EditUserFromAdminDto.Id);
            if (user == null) { return EditUserFromAdminResult.NotFound; }
            user.FirstName=request.EditUserFromAdminDto.FirstName;
            user.LastName=request.EditUserFromAdminDto.LastName;
            user.Gender = request.EditUserFromAdminDto.UserGender;
            if (!string.IsNullOrEmpty(request.EditUserFromAdminDto.Password))
            {
                user.Password = _passwordHelper.EncodePasswordMd5( request.EditUserFromAdminDto.Password);
            }
            await _userRepository.UpdateAsync(user);
            await _userroleRepository.RemoveAllUserSelectedroleAsync(request.EditUserFromAdminDto.Id);
            await _userroleRepository.AddUserToRoleAsync(request.EditUserFromAdminDto.RoleIds, request.EditUserFromAdminDto.Id);
            await _userRepository.SaveChangesAsync();
            return EditUserFromAdminResult.Success;
        }
    }
}
