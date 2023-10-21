using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Users.Requests.Commands;

namespace Shop.Application.Features.Account.Users.Handlers.Commands
{
    public class IsUserExistsCommandRequestHandler : IRequestHandler<IsUserExistsCommandRequest, bool>
    {
        private readonly IUserRepository _userRepository;

        public IsUserExistsCommandRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(IsUserExistsCommandRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.IsUserExistsbyPhonenumberAsync(request.PhoneNumber);
        }
    }
}
