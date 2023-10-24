using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.Utils.Paging;
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

        public async Task<FilterUserDto> FilterUserAsync(FilterUserDto filterUserDto)
        {
            var query = _context.Users.AsQueryable();
            #region Filter
            if (!string.IsNullOrEmpty(filterUserDto.PhoneNumber))
            {
                query = query.Where(u=>u.PhoneNumber == filterUserDto.PhoneNumber);
            }
            #endregion

            #region Paging
            var pager = Pager.Build(filterUserDto.PageId, await query.CountAsync(),
                filterUserDto.TakeEntity, filterUserDto.CountForShowAfterAndBefor);
            var allData = await query.Paging(pager).ToListAsync();
            #endregion

            return filterUserDto.SetPaging(pager).SetUsers(allData);
        }
    }
}
