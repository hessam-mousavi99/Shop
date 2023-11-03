using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Persistence.ModelConfigs.Account
{
    public class UserCompareConfigs : IEntityTypeConfiguration<UserCompare>
    {
        public void Configure(EntityTypeBuilder<UserCompare> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasOne<User>(c => c.User).WithMany(c => c.UserCompares);
            builder.HasOne<Product>(c => c.Product).WithMany(c => c.UserCompares);
        }
    }
}
