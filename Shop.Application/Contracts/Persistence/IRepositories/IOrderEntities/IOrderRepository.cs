using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Accounts;
using Shop.Application.DTOs.Admin.Order;
using Shop.Domain.Models.OrderEntities;

namespace Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> CheckUserOrderAsync(long userId);
        Task<Order> GetUserBasketAsync(long orderId, long userId);
        Task<Order> GetUserBasketAsync( long userId);
        Task<Order> GetOrderByIdAsync(long orderId, long userId);
        Task<FilterOrdersDto> FilterOrdersAsync(FilterOrdersDto filterOrders);
        Task<OrderStateResaultDto> GetResultOrder();
        Task<Order> GetOrderDetailAsync(long orderId);
    }
}
