using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Product.Product.Requests.Commands;
using Shop.Domain.Models.Account;

namespace Shop.Application.Features.Product.Product.Handlers.Commands
{
    public class AddProductToCompareCommandRequestHandler : IRequestHandler<AddProductToCompareCommandRequest, bool>
    {
        private readonly IUserCompareRepository _userCompareRepository;

        public AddProductToCompareCommandRequestHandler(IUserCompareRepository userCompareRepository)
        {
            _userCompareRepository = userCompareRepository;
        }
        public async Task<bool> Handle(AddProductToCompareCommandRequest request, CancellationToken cancellationToken)
        {
            if (!await _userCompareRepository.IsExistProductCompare(request.ProductId, request.UserId))
            {
                var newCompare = new UserCompare()
                {
                    ProductId = request.ProductId,
                    UserId = request.UserId,
                };
                await _userCompareRepository.AddAsync(newCompare);
                return true;
            }
            return false;
        }
    }
}
