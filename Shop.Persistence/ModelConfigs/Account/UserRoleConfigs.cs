using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Account;

namespace Shop.Persistence.ModelConfigs.Account
{
    public class UserRoleConfigs : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasOne<Role>(x => x.Role).WithMany(x => x.UserRoles);
            builder.HasOne<User>(x => x.User).WithMany(x => x.UserRoles);
        }
    }
}
