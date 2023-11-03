using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.OrderEntities;
using Shop.Domain.Models.ProductEntities;
using Shop.Domain.Models.Wallet;

namespace Shop.Persistence.ModelConfigs.Account
{
    public class UserConfigs : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasMany<UserWallet>(g => g.UserWallets).WithOne(s => s.User).HasForeignKey(s => s.UserId);
            builder.HasMany<UserRole>(g => g.UserRoles).WithOne(s => s.User).HasForeignKey(s => s.UserId);
            builder.HasMany<ProductComment>(x => x.ProductComments).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany<Order>(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany<UserCompare>(x => x.UserCompares).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany<UserFavorite>(x => x.UserFavorites).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
