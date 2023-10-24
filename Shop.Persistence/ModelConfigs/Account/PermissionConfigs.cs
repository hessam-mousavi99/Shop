using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Account;

namespace Shop.Persistence.ModelConfigs.Account
{
    public class PermissionConfigs : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasMany<RolePermission>(g => g.RolePermissions).WithOne(s => s.Permission).HasForeignKey(s => s.PermissionId);
            builder.HasMany<Permission>(p => p.Permissions).WithOne(p => p.ParentPermission).HasForeignKey(p => p.ParentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
