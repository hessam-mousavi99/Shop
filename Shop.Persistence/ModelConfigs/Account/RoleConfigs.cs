using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Account;

namespace Shop.Persistence.ModelConfigs.Account
{
    internal class RoleConfigs : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasMany<RolePermission>(g => g.RolePermissions).WithOne(s => s.Role).HasForeignKey(s => s.RoleId);
            builder.HasMany<UserRole>(g => g.UserRoles).WithOne(s => s.Role).HasForeignKey(s => s.RoleId);
        }
    }
}
