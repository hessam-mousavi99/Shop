using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence.IRepositories.IAccounts
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<bool> IsUserExistsbyPhonenumberAsync(string phoneNumber);
        Task SaveChangesAsync();
        Task<User> GetUserbyPhoneNumberAsync(string phonenumber);
    }
}
