using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IWallets;
using Shop.Application.DTOs.Wallet;
using Shop.Application.Utils.Paging;
using Shop.Domain.Enums;
using Shop.Domain.Models.Wallet;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.Wallets
{
    public class WalletRepository : GenericRepository<UserWallet>, IWalletRepository
    {
        private readonly ShopDBContext _context;

        public WalletRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FilterWalletDto> FilterWallets(FilterWalletDto filter)
        {
            var query=_context.Wallets.AsQueryable();
            #region Filter
            if (filter.UserId!=0 && filter.UserId!=null)
            {
                query = query.Where(w => w.UserId == filter.UserId);
            }
            #endregion

            #region Paging
            var pager = Pager.Build(filter.PageId, await query.CountAsync(), filter.TakeEntity, filter.CountForShowAfterAndBefor);
            var allData = await query.Paging(pager).ToListAsync();
            #endregion
            
            return filter.SetPaging(pager).SetWallets(allData);
        }

        public async Task SaveChangesAsync()
        {
          await _context.SaveChangesAsync();
        }
        public async Task<int> GetUserWalletAmountAsync(long userId)
        {
            var variz = await _context.Wallets.Where(c => c.UserId == userId && c.WalletType == WalletType.Variz && c.IsPay)
                .Select(c => c.Amount).ToListAsync();

            var bardasht = await _context.Wallets.Where(c => c.UserId == userId && c.WalletType == WalletType.Bardasht && c.IsPay)
                .Select(c => c.Amount).ToListAsync();

            return (variz.Sum() - bardasht.Sum());
        }
    }
}
