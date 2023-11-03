using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Domain.Models.Account;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.Accounts
{
    public class UserFavoriteRepository : GenericRepository<UserFavorite>, IUserFavoriteRepository
    {
        private readonly ShopDBContext _context;

        public UserFavoriteRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
