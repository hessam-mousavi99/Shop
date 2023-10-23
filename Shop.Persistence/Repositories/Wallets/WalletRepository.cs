using Shop.Application.Contracts.Persistence.IRepositories.IWallets;
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

        public async Task SaveChangesAsync()
        {
          await _context.SaveChangesAsync();
        }
    }
}
