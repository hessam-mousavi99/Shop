using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Admin.Product;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Contracts.Persistence.IRepositories.IProductEntities
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task SaveChangesAsync();
        Task<bool> CheckUrlNameCategoriesAsync(string urlName);
        Task<bool> CheckUrlNameCategoriesAsync(string urlName,long categoryId);
        Task<FilterCategoryDto> FilterCategoryAsync(FilterCategoryDto filterCategoryDto);
    }
}
