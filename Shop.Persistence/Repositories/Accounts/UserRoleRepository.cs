using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Domain.Models.Account;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.Accounts
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly ShopDBContext _context;

        public UserRoleRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddUserToRoleAsync(List<long> selectedRoles, long userId)
        {
           if(selectedRoles!=null && selectedRoles.Any())
            {
                var listUserRoles = new List<UserRole>();
                foreach (var roleId in selectedRoles)
                {
                    listUserRoles.Add(new UserRole()
                    {
                         RoleId = roleId,
                         UserId = userId
                    });
                }
                await _context.UserRoles.AddRangeAsync(listUserRoles);
                await SaveChangerAsync();
            }
        }

        public async Task RemoveAllUserSelectedroleAsync(long userId)
        {
           var allUserRoles= await _context.UserRoles.AsQueryable().Where(u=>u.UserId==userId).ToListAsync();
            if (allUserRoles.Any())
            {
                _context.UserRoles.RemoveRange(allUserRoles);
                await SaveChangerAsync();
            }
        }

        public async Task SaveChangerAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
