using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.Wallet;

namespace Shop.Persistence.Context
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options):base(options) { }

        #region User
        public DbSet<User> Users { get; set; }
        #endregion
        #region Wallet
        public DbSet<UserWallet> Wallets { get; set; }
        #endregion


        #region Config Relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDBContext).Assembly);
        }
        #endregion
    }
}
