using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Domain.Enums;
using Shop.Domain.Models.Account;

namespace Shop.Application.Features.Account.Users.Handlers.Commands
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, RegisterUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHelper _passwordHelper;
        private readonly ISmsService _smsService;

        public CreateUserRequestHandler(IUserRepository userRepository, IMapper mapper,IPasswordHelper passwordHelper,ISmsService smsService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHelper = passwordHelper;
            _smsService = smsService;
            
        }
        public async Task<RegisterUserResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if (!await _userRepository.IsUserExistsbyPhonenumberAsync(request.CreateUserDto.PhoneNumber))
            {
                var user = _mapper.Map<User>(request.CreateUserDto);
                user.Password = _passwordHelper.EncodePasswordMd5(request.CreateUserDto.Password);
                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                await _smsService.SendVerificationCodeAsync(user.PhoneNumber, user.ActiveCode);

                return RegisterUserResult.Success;
            }
            else
            {
                return RegisterUserResult.MobileExists;
            }
        }
    }
}
