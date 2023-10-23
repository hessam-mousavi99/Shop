using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.Wallet;

namespace Shop.Persistence.ModelConfigs.Wallet
{
    public class WalletConfigs : IEntityTypeConfiguration<UserWallet>
    {
        public void Configure(EntityTypeBuilder<UserWallet> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete != false);
            builder.HasOne<User>(g => g.User).WithMany(s => s.UserWallets);
        }
    }
}
