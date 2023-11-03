using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Features.Product.Product.Requests.Queries;

namespace Shop.Application.Features.Product.Product.Handlers.Queries
{
    public class FilterFavoritesRequestHandler : IRequestHandler<FilterFavoritesRequest, UserFavoriteDto>
    {
        private readonly IUserFavoriteRepository _userFavoriteRepository;

        public FilterFavoritesRequestHandler(IUserFavoriteRepository userFavoriteRepository)
        {
            _userFavoriteRepository = userFavoriteRepository;
        }

        public async Task<UserFavoriteDto> Handle(FilterFavoritesRequest request, CancellationToken cancellationToken)
        {
            return await _userFavoriteRepository.UserFavorite(request.UserFavoriteDto);
        }
    }
}
