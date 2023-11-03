using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Product.Product.Requests.Commands;
using Shop.Domain.Models.Account;

namespace Shop.Application.Features.Product.Product.Handlers.Commands
{
    internal class AddProductToFavoritCommandRequestHandler : IRequestHandler<AddProductToFavoritCommandRequest, bool>
    {
        private readonly IUserFavoriteRepository _userFavoriteRepository;

        public AddProductToFavoritCommandRequestHandler(IUserFavoriteRepository userFavoriteRepository)
        {
           _userFavoriteRepository = userFavoriteRepository;
        }
        public async Task<bool> Handle(AddProductToFavoritCommandRequest request, CancellationToken cancellationToken)
        {
            if (!await _userFavoriteRepository.IsExistProductFavorit(request.ProductId,request.UserId)) 
            {
                var newFavorite = new UserFavorite()
                {
                    ProductId = request.ProductId,
                    UserId = request.UserId,
                };
                await _userFavoriteRepository.AddAsync(newFavorite);
                return true;
            }
            return false;
        }
    }
}
