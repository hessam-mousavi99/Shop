using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Domain.Models.OrderEntities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.OrderEntities
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ShopDBContext _context;

        public OrderRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
