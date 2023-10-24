using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Domain.Models.Account;

namespace Shop.Application.Contracts.Persistence.IRepositories.IAccounts
{
    public interface IRolePermissionRepository : IGenericRepository<RolePermission>
    {
        Task SaveChangerAsync();
        Task RemoveAllPermissionSelectedroleAsync(long roleId);
        Task AddPermissionToRoleAsync(List<long> selectedPermissions, long roleId);
    }
}
