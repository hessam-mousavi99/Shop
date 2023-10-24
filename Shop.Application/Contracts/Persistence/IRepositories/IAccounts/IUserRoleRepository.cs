using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Domain.Models.Account;

namespace Shop.Application.Contracts.Persistence.IRepositories.IAccounts
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        Task SaveChangerAsync();
        Task RemoveAllUserSelectedroleAsync(long userId);
        Task AddUserToRoleAsync(List<long> selectedRoles, long userId);
    }
}
