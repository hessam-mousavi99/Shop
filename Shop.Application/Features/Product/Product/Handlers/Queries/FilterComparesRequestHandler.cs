using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Features.Product.Product.Requests.Queries;

namespace Shop.Application.Features.Product.Product.Handlers.Queries
{
    public class FilterComparesRequestHandler : IRequestHandler<FilterComparesRequest, UserCompareDto>
    {
        private readonly IUserCompareRepository _userCompareRepository;

        public FilterComparesRequestHandler(IUserCompareRepository userCompareRepository)
        {
            _userCompareRepository = userCompareRepository;
        }
        public async Task<UserCompareDto> Handle(FilterComparesRequest request, CancellationToken cancellationToken)
        {
            return await _userCompareRepository.UserCompares(request.UserCompareDto);
        }
    }
}
