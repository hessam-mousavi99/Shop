using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.Wallet;

namespace Shop.Persistence.ModelConfigs.Account
{
    public class UserConfigs : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasMany<UserWallet>(g => g.UserWallets).WithOne(s => s.User).HasForeignKey(s => s.UserId);
        }
    }
}
