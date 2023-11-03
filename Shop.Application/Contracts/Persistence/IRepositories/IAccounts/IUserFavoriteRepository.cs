using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Models.Account;

namespace Shop.Application.Contracts.Persistence.IRepositories.IAccounts
{
    public interface IUserFavoriteRepository:IGenericRepository<UserFavorite>
    {
        Task<bool> IsExistProductFavorit(long productId, long userId);
        Task<UserFavoriteDto> UserFavorite(UserFavoriteDto userFavoriteDto);
        Task<int> UserFavoritCountAsync(long userId);
    }
}
