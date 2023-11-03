using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Users.Requests.Queries;

namespace Shop.Application.Features.Account.Users.Handlers.Queries
{
    public class UserFavoritCountRequestHandler : IRequestHandler<UserFavoritCountRequest, int>
    {
        private readonly IUserFavoriteRepository _userFavoriteRepository;

        public UserFavoritCountRequestHandler(IUserFavoriteRepository userFavoriteRepository)
        {
            _userFavoriteRepository = userFavoriteRepository;
        }
        public async Task<int> Handle(UserFavoritCountRequest request, CancellationToken cancellationToken)
        {
            return await _userFavoriteRepository.UserFavoritCountAsync(request.UserId);
        }
    }
}
