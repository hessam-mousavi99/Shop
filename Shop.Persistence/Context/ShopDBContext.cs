using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.Account;

namespace Shop.Persistence.Context
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options):base(options) { }

        #region User
        public DbSet<User> Users { get; set; }
        #endregion


        #region Config Relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDBContext).Assembly);
        }
        #endregion
    }
}
