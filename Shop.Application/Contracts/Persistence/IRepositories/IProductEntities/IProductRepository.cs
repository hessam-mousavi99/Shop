using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.DTOs.Site;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Contracts.Persistence.IRepositories.IProductEntities
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task SaveChangesAsync();
        Task<FilterProductsDto> FilterProducts(FilterProductsDto filterProductsDto);
        Task<bool> CheckProductExist(long productId);
        Task<List<ProductItemDto>> ShowAllProductsInSlider();
        Task<List<ProductItemDto>> ShowAllProductsInCategory(string hrefName);
        Task<List<ProductItemDto>> LastProducts();
        Task<ProductDetailDto> ShowProductDetailAsync(long productId);
        Task<List<ProductItemDto>> GetRelatedProduct(string cateName, long productId);

    }
}
