using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Models.Account;

namespace Shop.Application.Contracts.Persistence.IRepositories.IAccounts
{
    public interface IUserCompareRepository:IGenericRepository<UserCompare>
    {
        Task<bool> IsExistProductCompare(long productId, long userId);
        Task<UserCompareDto> UserCompares(UserCompareDto userCompareDto);
        Task RemoveAllRangeUserCompareAsync(long userId);
        Task<List<UserCompare>> GetUserComparesAsync(long userId);
    }
}
