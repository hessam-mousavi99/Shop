using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Contracts.Persistence.IRepositories.IProductEntities
{
    public interface IProductGalleryRepository:IGenericRepository<ProductGallery>
    {
        Task AddProductGalleries(List<ProductGallery> productGalleries);
        Task<List<ProductGallery>> GetProductGalleriesAsync(long productId);
    }
}
