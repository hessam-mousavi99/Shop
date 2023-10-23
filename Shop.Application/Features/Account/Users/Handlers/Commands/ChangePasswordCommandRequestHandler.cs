using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Users.Handlers.Commands
{
    public class ChangePasswordCommandRequestHandler : IRequestHandler<ChangePasswordCommandRequest, ChangePasswordResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHelper _passwordHelper;

        public ChangePasswordCommandRequestHandler(IUserRepository userRepository, IMapper mapper,IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHelper = passwordHelper;
        }
        public async Task<ChangePasswordResult> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);
            if (user!=null)
            {
                var newPass = _passwordHelper.EncodePasswordMd5(request.ChangePasswordDto.NewPassword);
                if (user.Password!=newPass)
                {
                    user.Password = newPass;
                    await _userRepository.UpdateAsync(user);
                    await _userRepository.SaveChangesAsync();

                    return ChangePasswordResult.Success;
                }
                return ChangePasswordResult.PasswordEqual;
            }
            return ChangePasswordResult.NotFound;
        }
    }
}
