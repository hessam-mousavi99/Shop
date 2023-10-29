using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Admin.Account;
using Shop.Domain.Models.Account;

namespace Shop.Application.Contracts.Persistence.IRepositories.IAccounts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> IsUserExistsbyPhonenumberAsync(string phoneNumber);
        Task SaveChangesAsync();
        Task<User> GetUserbyPhoneNumberAsync(string phonenumber);
        Task<FilterUserDto> FilterUserAsync(FilterUserDto filterUserDto);
        bool CheckPermission(long permissionId, string phoneNumber);
    }
}
