using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Users.Requests.Commands;

namespace Shop.Application.Features.Account.Users.Handlers.Commands
{
    public class RemoveUserCompareCommandRequestHandler : IRequestHandler<RemoveUserCompareCommandRequest, bool>
    {
        private readonly IUserCompareRepository _userCompareRepository;

        public RemoveUserCompareCommandRequestHandler(IUserCompareRepository userCompareRepository)
        {
            _userCompareRepository = userCompareRepository;
        }
        public async Task<bool> Handle(RemoveUserCompareCommandRequest request, CancellationToken cancellationToken)
        {
            var compare=await _userCompareRepository.GetAsync(request.Id);
            if (compare != null)
            {
                await _userCompareRepository.DeleteAsync(compare);
                return true;
            }
            return false;
        }
    }
}
