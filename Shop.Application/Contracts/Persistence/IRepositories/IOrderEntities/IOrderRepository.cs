using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Domain.Models.OrderEntities;

namespace Shop.Application.Contracts.Persistence.IRepositories.IOrderEntities
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
