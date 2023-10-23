using MediatR;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Users.Handlers.Commands
{
    public class LoginUserCommandRequestHandler : IRequestHandler<LoginUserCommandRequest, LoginUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelper _passwordHelper;

        public LoginUserCommandRequestHandler(IUserRepository userRepository,IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
        }
        public async Task<LoginUserResult> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserbyPhoneNumberAsync(request.LoginDto.PhoneNumber);
            if (user == null) return LoginUserResult.NotFound;
            if (user.IsBlocked==true) return LoginUserResult.IsBlocked;
            if (user.IsActive == false) return LoginUserResult.NotActive;
            if (user.Password != _passwordHelper.EncodePasswordMd5(request.LoginDto.Password)) return LoginUserResult.NotFound;

            return LoginUserResult.Success;
        }
    }
}
