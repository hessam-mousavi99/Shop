using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IWallets;
using Shop.Application.DTOs.Wallet;
using Shop.Application.Utils.Paging;
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
    }
}
