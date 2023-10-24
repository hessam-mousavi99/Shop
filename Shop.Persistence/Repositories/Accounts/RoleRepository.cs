using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.Utils.Paging;
using Shop.Domain.Models.Account;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.Accounts
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly ShopDBContext _context;

        public RoleRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FilterRolesDto> FilterRolesAsync(FilterRolesDto filterRolesDto)
        {
            var query = _context.Roles.AsQueryable();
            #region Filter
            if (!string.IsNullOrEmpty(filterRolesDto.RoleName))
            {
                query = query.Where(c => EF.Functions.Like(c.RoleTitle, $"%{filterRolesDto.RoleName}%"));
            }
            #endregion

            #region Paging
            var pager = Pager.Build(filterRolesDto.PageId, await query.CountAsync(),
                filterRolesDto.TakeEntity, filterRolesDto.CountForShowAfterAndBefor);
            var allData = await query.Paging(pager).ToListAsync();
            #endregion

            return filterRolesDto.SetPaging(pager).SetRoles(allData);
        }

        public async Task<CreateOrEditRoleDto> GetEditRoleById(long roleId)
        {
            return await _context.Roles.AsQueryable().Where(c => c.Id == roleId).Include(c=>c.RolePermissions)
                .Select(c => new CreateOrEditRoleDto()
                {
                    Id = roleId,
                    RoleTitle = c.RoleTitle,
                    SelectedPermission = c.RolePermissions.Select(c => c.PermissionId).ToList()
                }).SingleOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
