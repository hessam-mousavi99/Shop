using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.Utils.Paging;
using Shop.Domain.Enums;
using Shop.Domain.Models.ProductEntities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.ProductEntities
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ShopDBContext _context;

        public ProductRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckProductExist(long productId)
        {
            return await _context.Products.AsQueryable().AnyAsync(c=>c.Id==productId);
        }

        public async Task<FilterProductsDto> FilterProducts(FilterProductsDto filterProductsDto)
        {
            var query = _context.Products.Include(p => p.ProductCategories).ThenInclude(p => p.Category).AsQueryable();

            #region Filter
            if (!string.IsNullOrEmpty(filterProductsDto.ProductName))
            {
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{filterProductsDto.ProductName}%"));
            }
            if (!string.IsNullOrEmpty(filterProductsDto.FilterByCategory))
            {
                query = query.Where(p => p.ProductCategories.Any(pc => pc.Category.UrlName == filterProductsDto.FilterByCategory));
            }
            #endregion

            #region State
            switch (filterProductsDto.ProductState)
            {
                case ProductState.All:
                    query = query.Where(c => !c.IsDelete);
                    break;
                case ProductState.IsActice:
                    query = query.Where(p => p.IsActive);
                    break;
                case ProductState.Delete:
                    query = query.Where(p => p.IsDelete);
                    break;
            }
            #endregion

            #region Order
            switch (filterProductsDto.ProductOrder)
            {
                case ProductOrder.All:
                    break;
                case ProductOrder.ProductNewss:
                    query = query.Where(p => p.IsActive).OrderByDescending(p => p.CreateDate);
                    break;
                case ProductOrder.ProductExp:
                    query = query.Where(p => p.IsActive).OrderByDescending(p => p.Price);
                    break;
                case ProductOrder.ProductInExpensive:
                    query = query.Where(p => p.IsActive).OrderBy(p => p.Price);
                    break;
            }
            #endregion

            #region paging
            var pager = Pager.Build(filterProductsDto.PageId, await query.CountAsync(), filterProductsDto.TakeEntity, filterProductsDto.CountForShowAfterAndBefor);
            var allData = await query.Paging(pager).ToListAsync();
            #endregion
            return filterProductsDto.SetPaging(pager).SetProducts(allData);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
