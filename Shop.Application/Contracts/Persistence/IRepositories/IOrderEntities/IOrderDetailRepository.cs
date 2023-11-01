using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Domain.Models.OrderEntities;

namespace Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        Task<OrderDetail> CheckOrderDetailExistsAsync(long orderId, long productId);
        Task<int> OrderSumAsync(long orderId);
    }
}
