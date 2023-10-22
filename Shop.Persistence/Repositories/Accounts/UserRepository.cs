using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Models.Account;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;
using System.Reflection.Metadata;

namespace Shop.Persistence.Repositories.Accounts
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ShopDBContext _context;

        public UserRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsUserExistsbyPhonenumberAsync(string phoneNumber)
        {
            return await _context.Users.AsQueryable().AnyAsync(u => u.PhoneNumber == phoneNumber);
        }
        public async Task<User> GetUserbyPhoneNumberAsync(string phonenumber)
        {
            return await _context.Users.AsQueryable().SingleOrDefaultAsync(u => u.PhoneNumber == phonenumber);
        }
        

        public async Task SaveChangesAsync()
        {
          await _context.SaveChangesAsync();
        }

        public Task<ActiveAccountResult> ActiveAccountAsync(ActiveAccountDto activeAccountDto)
        {
            throw new NotImplementedException();
        }
    }
}
