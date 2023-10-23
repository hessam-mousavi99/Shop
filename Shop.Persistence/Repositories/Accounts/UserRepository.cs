using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Domain.Models.Account;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

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
            var user= await _context.Users.AsQueryable().SingleOrDefaultAsync(u => u.PhoneNumber == phonenumber);
            return user; 
        }
        

        public async Task SaveChangesAsync()
        {
          await _context.SaveChangesAsync();
        }
    }
}
