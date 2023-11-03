using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities;
using Shop.Application.DTOs.Accounts;
using Shop.Application.DTOs.Admin.Order;
using Shop.Application.Utils.Paging;
using Shop.Domain.Enums;
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
            return _context.Orders.AsQueryable().OrderByDescending(c=>c.Id).Take(1).FirstOrDefaultAsync(c => c.UserId == userId && (c.OrderState == OrderState.Processing|| c.OrderState == OrderState.Sent)  && !c.IsFinaly);
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
                    OrderState = c.OrderState,
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

        public async Task<FilterOrdersDto> FilterOrdersAsync(FilterOrdersDto filterOrders)
        {
            var query = _context.Orders.Include(c => c.OrderDetails).Include(c => c.User).AsQueryable();

            if (filterOrders.UserId.HasValue && filterOrders.UserId != 0)
            {
                query = query.Where(c => c.UserId == filterOrders.UserId);
            }

            switch (filterOrders.OrderStateFilter)
            {
                case OrderStateFilter.All:
                    break;
                case OrderStateFilter.Requested:
                    query = query.Where(c => c.OrderState == OrderState.Requested);
                    break;
                case OrderStateFilter.Processing:
                    query = query.Where(c => c.OrderState == OrderState.Processing);
                    break;
                case OrderStateFilter.Sent:
                    query = query.Where(c => c.OrderState == OrderState.Sent);
                    break;
                case OrderStateFilter.Cancel:
                    query = query.Where(c => c.OrderState == OrderState.Cancel);
                    break;
            }
            var pager = Pager.Build(filterOrders.PageId, await query.CountAsync(), filterOrders.TakeEntity, filterOrders.CountForShowAfterAndBefor);
            var allData = await query.Paging(pager).ToListAsync();
            return filterOrders.SetPaging(pager).SetOrders(allData);

        }

        public async Task<Order> GetUserBasketAsync(long userId)
        {
            return await _context.Orders.AsQueryable()
               .Include(c => c.User)
               .Where(c => c.UserId == userId && c.IsFinaly==false)
               .Select(c => new Order
               {
                   UserId = c.UserId,
                   CreateDate = c.CreateDate,
                   Id = c.Id,
                   IsDelete = c.IsDelete,
                   OrderState = c.OrderState,
                   IsFinaly = c.IsFinaly,
                   OrderSum = c.OrderSum,
                   OrderDetails = _context.OrderDetails.Where(c => !c.Order.IsFinaly && c.Order.UserId == userId).Include(c => c.Product).ToList()
               }).FirstOrDefaultAsync();
        }

        public async Task<OrderStateResaultDto> GetResultOrder()
        {
            return new OrderStateResaultDto()
            {
                CancelCount = await _context.Orders.AsQueryable().Where(c => c.OrderState == OrderState.Cancel && c.CreateDate.Day == DateTime.Now.Day).CountAsync(),
                RequestCount = await _context.Orders.AsQueryable().Where(c => c.OrderState == OrderState.Requested).CountAsync(),
                ProcessingCount = await _context.Orders.AsQueryable().Where(c => c.OrderState == OrderState.Processing && c.CreateDate.Day == DateTime.Now.Day).CountAsync(),
                SentCount = await _context.Orders.AsQueryable().Where(c => c.OrderState == OrderState.Sent).CountAsync()
            };
        }

        public async Task<Order> GetOrderDetailAsync(long orderId)
        {
            return await _context.Orders.Include(c => c.OrderDetails).ThenInclude(c => c.Product).Include(c => c.User).AsQueryable()
                 .Where(c => c.Id == orderId).SingleOrDefaultAsync();
        }
    }
}
