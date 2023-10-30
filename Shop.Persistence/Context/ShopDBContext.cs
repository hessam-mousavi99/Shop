using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.ProductEntities;
using Shop.Domain.Models.Site;
using Shop.Domain.Models.Wallet;

namespace Shop.Persistence.Context
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options):base(options) { }

        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        #endregion

        #region Wallet
        public DbSet<UserWallet> Wallets { get; set; }
        #endregion

        #region Product
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        #endregion

        #region site
        public DbSet<Slider> Sliders { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        #region Config Relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDBContext).Assembly);
        }
        #endregion
    }
}
