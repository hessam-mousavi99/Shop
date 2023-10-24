using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Admin.Account;
using Shop.Domain.Models.Account;

namespace Shop.Application.Contracts.Persistence.IRepositories.IAccounts
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task SaveChangesAsync();
        Task<FilterRolesDto> FilterRolesAsync(FilterRolesDto filterRolesDto);
        Task<CreateOrEditRoleDto> GetEditRoleById(long roleId);
    }
}
