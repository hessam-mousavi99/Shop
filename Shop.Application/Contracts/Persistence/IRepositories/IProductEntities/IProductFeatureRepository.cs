using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Contracts.Persistence.IRepositories.IProductEntities
{
    public interface IProductFeatureRepository:IGenericRepository<ProductFeature>
    {
        Task<List<ProductFeature>> GetProductFeaturesAsync(long productId);
    }
}
