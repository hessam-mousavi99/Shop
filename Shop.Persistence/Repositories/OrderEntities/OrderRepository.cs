using Microsoft.EntityFrameworkCore;
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

        public Task<Order> CheckUserOrderAsync(long userId)
        {
            return _context.Orders.AsQueryable().FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<Order> GetUserBasketAsync(long orderId, long userId)
        {
            return await _context.Orders.AsQueryable()
                .Include(c => c.User)
                .Where(c => c.UserId == userId && c.Id == orderId)
                .Select(c => new Order
                {
                    UserId = c.UserId,
                    CreateDate = c.CreateDate,
                    Id = c.Id,
                    IsDelete = c.IsDelete,
                    OrderState=c.OrderState,
                    IsFinaly = c.IsFinaly,
                    OrderSum = c.OrderSum,
                    OrderDetails = _context.OrderDetails.Where(c => !c.Order.IsFinaly && c.Order.UserId == userId).Include(c => c.Product).ToList()
                }).FirstOrDefaultAsync();
        }
        public async Task<Order> GetOrderByIdAsync(long orderId, long userId)
        {
            return await _context.Orders.AsQueryable()
               .SingleOrDefaultAsync(c => c.Id == orderId && c.UserId == userId);
        }
    }
}
