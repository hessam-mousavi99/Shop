using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Users.Requests.Queries;
using Shop.Domain.Models.Account;

namespace Shop.Application.Features.Account.Users.Handlers.Queries
{
    public class GetUserComparesRequestHandler : IRequestHandler<GetUserComparesRequest, List<UserCompare>>
    {
        private readonly IUserCompareRepository _userCompareRepository;

        public GetUserComparesRequestHandler(IUserCompareRepository userCompareRepository)
        {
            _userCompareRepository = userCompareRepository;
        }
        public async Task<List<UserCompare>> Handle(GetUserComparesRequest request, CancellationToken cancellationToken)
        {
            return await _userCompareRepository.GetUserComparesAsync(request.UserId);
        }
    }
}
