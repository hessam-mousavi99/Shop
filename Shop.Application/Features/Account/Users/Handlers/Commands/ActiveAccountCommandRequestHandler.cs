using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Users.Handlers.Commands
{
    public class ActiveAccountCommandRequestHandler : IRequestHandler<ActiveAccountCommandRequest, ActiveAccountResult>
    {
        private readonly IUserRepository _userRepository;
    
        public ActiveAccountCommandRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ActiveAccountResult> Handle(ActiveAccountCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserbyPhoneNumberAsync(request.activeAccountDto.PhoneNumber);
            if (user == null) return ActiveAccountResult.NotFound;
            if (user.ActiveCode == request.activeAccountDto.ActiveCode)
            {
                user.ActiveCode = new Random().Next(10000, 99999).ToString();
                user.IsActive = true;
                await _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangesAsync();
                return ActiveAccountResult.Success;
            }
            return ActiveAccountResult.Error;
        }
    }
}
