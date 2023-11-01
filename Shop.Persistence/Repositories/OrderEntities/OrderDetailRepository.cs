using Microsoft.EntityFrameworkCore;
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

        public async Task<OrderDetail> CheckOrderDetailExistsAsync(long orderId, long productId)
        {
            return await _context.OrderDetails.AsQueryable()
                .Where(c => c.OrderId == orderId && c.ProductId == productId).FirstOrDefaultAsync();
        }

        public async Task<int> OrderSumAsync(long orderId)
        {
            var ordersum= await _context.OrderDetails.AsQueryable().Where(c => c.OrderId == orderId).SumAsync(c => c.Price * c.Count);
            return ordersum;
        }
    }
}
