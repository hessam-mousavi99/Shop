using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Domain.Models.Account;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.Accounts
{
    public class UserCompareRepository : GenericRepository<UserCompare>, IUserCompareRepository
    {
        private readonly ShopDBContext _context;

        public UserCompareRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
