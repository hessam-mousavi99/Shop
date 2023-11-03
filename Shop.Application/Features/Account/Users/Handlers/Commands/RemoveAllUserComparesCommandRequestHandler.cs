using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Users.Requests.Commands;

namespace Shop.Application.Features.Account.Users.Handlers.Commands
{
    public class RemoveAllUserComparesCommandRequestHandler : IRequestHandler<RemoveAllUserComparesCommandRequest, bool>
    {
        private readonly IUserCompareRepository _userCompareRepository;

        public RemoveAllUserComparesCommandRequestHandler(IUserCompareRepository userCompareRepository)
        {
           _userCompareRepository = userCompareRepository;
        }

        public async Task<bool> Handle(RemoveAllUserComparesCommandRequest request, CancellationToken cancellationToken)
        {
             await _userCompareRepository.RemoveAllRangeUserCompareAsync(request.UserId);
            return true;
        }
    }
}
