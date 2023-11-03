using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Utils.Paging;
using Shop.Domain.Models.Account;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.Accounts
{
    public class UserCompareRepository : GenericRepository<UserCompare>, IUserCompareRepository
    {
        private readonly ShopDBContext _context;

        public UserCompareRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UserCompare>> GetUserComparesAsync(long userId)
        {
            return await _context.UserCompares.AsQueryable().Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<bool> IsExistProductCompare(long productId, long userId)
        {
            return await _context.UserCompares.AsQueryable().AnyAsync(c => c.ProductId == productId && c.UserId == userId);
        }

        public async Task RemoveAllRangeUserCompareAsync(long userId)
        {
            var data = await _context.UserCompares.Where(c => c.UserId == userId).ToListAsync();


            if (data != null && data.Any())
            {
                _context.UserCompares.RemoveRange(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UserCompareDto> UserCompares(UserCompareDto userCompareDto)
        {
            var query = _context.UserCompares.Include(c => c.Product).ThenInclude(c => c.ProductFeatures).AsQueryable();

            #region paging
            var pager = Pager.Build(userCompareDto.PageId, await query.CountAsync(), userCompareDto.TakeEntity, userCompareDto.CountForShowAfterAndBefor);
            var allData = await query.Paging(pager).ToListAsync();
            #endregion

            return userCompareDto.SetPaging(pager).SetCompares(allData);

        }
    }
}
