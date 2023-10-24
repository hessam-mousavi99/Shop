using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Domain.Models.Account;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.Accounts
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly ShopDBContext _context;

        public PermissionRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
