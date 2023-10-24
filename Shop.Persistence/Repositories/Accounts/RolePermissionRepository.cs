using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Domain.Models.Account;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.Accounts
{
    public class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
    {
        private readonly ShopDBContext _context;

        public RolePermissionRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddPermissionToRoleAsync(List<long> selectedPermissions, long roleId)
        {
            if (selectedPermissions!=null &&selectedPermissions.Any())
            {
                var rolePermissions = new List<RolePermission>();
                foreach (var permissionId in selectedPermissions)
                {
                    rolePermissions.Add(new RolePermission()
                    {
                        PermissionId = permissionId,
                        RoleId = roleId
                    });
                }
                await _context.RolePermissions.AddRangeAsync(rolePermissions);
            }
        }

        public async Task RemoveAllPermissionSelectedroleAsync(long roleId)
        {
            var AllRolePermissions = await _context.RolePermissions.Where(c => c.RoleId == roleId).ToListAsync();

            if (AllRolePermissions.Any())
            {
                _context.RolePermissions.RemoveRange(AllRolePermissions);
            }
        }

        public async Task SaveChangerAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
