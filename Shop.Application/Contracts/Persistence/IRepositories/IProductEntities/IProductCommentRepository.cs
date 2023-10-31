using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Contracts.Persistence.IRepositories.IProductEntities
{
    public interface IProductCommentRepository:IGenericRepository<ProductComment>
    {
        Task<List<ProductComment>> GetAllCommentsByIdAsync(long productId);
    }
}
