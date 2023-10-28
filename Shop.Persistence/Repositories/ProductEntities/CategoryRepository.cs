using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.Utils.Paging;
using Shop.Domain.Models.ProductEntities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.ProductEntities
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ShopDBContext _context;

        public CategoryRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckUrlNameCategoriesAsync(string urlName)
        {
            return await _context.Categories.AsQueryable().AnyAsync(c => c.UrlName == urlName);
        }

        public async Task<bool> CheckUrlNameCategoriesAsync(string urlName, long categoryId)
        {
            return await _context.Categories.AsQueryable().AnyAsync(c => c.UrlName == urlName && c.Id!=categoryId);
        }

        public async Task<FilterCategoryDto> FilterCategoryAsync(FilterCategoryDto filterCategoryDto)
        {
            var query = _context.Categories.AsQueryable();
            #region Filter
            if (!string.IsNullOrEmpty(filterCategoryDto.Title))
            {
                query = query.Where(c=>EF.Functions.Like(c.Title,$"%{filterCategoryDto.Title}%"));
            }
            #endregion

            #region Paging
            var pager = Pager.Build(filterCategoryDto.PageId, await query.CountAsync(),
                filterCategoryDto.TakeEntity, filterCategoryDto.CountForShowAfterAndBefor);
            var allData = await query.Paging(pager).ToListAsync();
            #endregion

            return filterCategoryDto.SetPaging(pager).SetCategories(allData);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
