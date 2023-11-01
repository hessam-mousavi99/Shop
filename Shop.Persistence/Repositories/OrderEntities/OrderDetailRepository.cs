using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Domain.Models.OrderEntities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.OrderEntities
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ShopDBContext _context;

        public OrderDetailRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
