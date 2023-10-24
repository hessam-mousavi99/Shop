using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.Wallet;

namespace Shop.Persistence.ModelConfigs.Account
{
    public class RolePermissionConfigs : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasOne<Role>(x => x.Role).WithMany(x => x.RolePermissions);
            builder.HasOne<Permission>(x => x.Permission).WithMany(x => x.RolePermissions);
           
        }
    }
}
