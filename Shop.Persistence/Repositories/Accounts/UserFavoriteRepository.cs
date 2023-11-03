using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Utils.Paging;
using Shop.Domain.Models.Account;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.Accounts
{
    public class UserFavoriteRepository : GenericRepository<UserFavorite>, IUserFavoriteRepository
    {
        private readonly ShopDBContext _context;

        public UserFavoriteRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsExistProductFavorit(long productId, long userId)
        {
            return await _context.UserFavorites.AsQueryable().AnyAsync(c => c.ProductId == productId && c.UserId == userId);
        }

        public async Task<int> UserFavoritCountAsync(long userId)
        {
            var count = await _context.UserFavorites.AsQueryable().Where(c => c.UserId == userId).CountAsync();
            if (count == null)
            {
                return 0;
            }
            return count;
        }

        public async Task<UserFavoriteDto> UserFavorite(UserFavoriteDto userFavoriteDto)
        {
            var query = _context.UserFavorites.Include(c => c.Product).AsQueryable();

            #region paging
            var pager = Pager.Build(userFavoriteDto.PageId, await query.CountAsync(), userFavoriteDto.TakeEntity, userFavoriteDto.CountForShowAfterAndBefor);
            var allData = await query.Paging(pager).ToListAsync();
            #endregion

            return userFavoriteDto.SetPaging(pager).SetFavorites(allData);
        }
    }
}
