using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.DTOs.Site;
using Shop.Application.Utils.Paging;
using Shop.Domain.Enums;
using Shop.Domain.Models.ProductEntities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;
using System.Web.Mvc;

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
            return await _context.Products.AsQueryable().AnyAsync(c => c.Id == productId);
        }

        public async Task<FilterProductsDto> FilterProducts(FilterProductsDto filterProductsDto)
        {
            var query = _context.Products.Include(c => c.ProductComments).Include(p => p.ProductCategories).ThenInclude(p => p.Category).AsQueryable();

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

            #region ProductBox
            switch (filterProductsDto.ProductBox)
            {
                case ProductBox.Default:
                    break;
                case ProductBox.ItemBoxInSite:
                    var pagerBox = Pager.Build(filterProductsDto.PageId, await query.CountAsync(), filterProductsDto.TakeEntity, filterProductsDto.CountForShowAfterAndBefor);
                    var allDataBox = await query.Paging(pagerBox).Select(c => new ProductItemDto
                    {
                        Category = c.ProductCategories.Select(c => c.Category).First(),
                        CommentCount = c.ProductComments.Count(),
                        Price = c.Price,
                        ProductId = c.Id,
                        ProductImageName = c.ProductImageName,
                        ProductName = c.Name
                    }).ToListAsync();
                    return filterProductsDto.SetPaging(pagerBox).SetProductsItem(allDataBox);

            }
            #endregion
            var pager = Pager.Build(filterProductsDto.PageId, await query.CountAsync(), filterProductsDto.TakeEntity, filterProductsDto.CountForShowAfterAndBefor);
            var allData = await query.Paging(pager).ToListAsync();
            return filterProductsDto.SetPaging(pager).SetProducts(allData);
        }

        public async Task<List<ProductItemDto>> LastProducts()
        {
            var lastproducts = await _context.Products.Include(c => c.ProductComments).Include(c => c.ProductCategories).ThenInclude(c => c.Category).AsQueryable()
                 .OrderByDescending(c => c.CreateDate).Select(c => new ProductItemDto()
                 {
                     Category = c.ProductCategories.Select(c => c.Category).First(),
                     CommentCount = c.ProductComments.Count(),
                     Price = c.Price,
                     ProductId = c.Id,
                     ProductImageName = c.ProductImageName,
                     ProductName = c.Name
                 }).Take(8).ToListAsync();
            return lastproducts;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductItemDto>> ShowAllProductsInCategory(string hrefName)
        {
            var product = await _context.Products.Include(c=>c.ProductComments).Include(c => c.ProductCategories).
                ThenInclude(c => c.Category).Where(c => c.ProductCategories.
                Any(c => c.Category.UrlName == hrefName)).ToListAsync();

            var data = product.Select(c => new ProductItemDto
            {
                Category = c.ProductCategories.Select(c => c.Category).First(),
                CommentCount = c.ProductComments.Count(),
                Price = c.Price,
                ProductId = c.Id,
                ProductImageName = c.ProductImageName,
                ProductName = c.Name
            }).ToList();

            return data;
        }

        public async Task<List<ProductItemDto>> ShowAllProductsInSlider()
        {
            var allProduct = await _context.Products.Include(c => c.ProductComments).Include(c => c.ProductCategories).ThenInclude(c => c.Category).AsQueryable()
              .Select(c => new ProductItemDto
              {
                  Category = c.ProductCategories.Select(c => c.Category).First(),
                  CommentCount = c.ProductComments.Count(),
                  Price = c.Price,
                  ProductId = c.Id,
                  ProductImageName = c.ProductImageName,
                  ProductName = c.Name
              }).ToListAsync();

            return allProduct;
        }

        public async Task<ProductDetailDto> ShowProductDetailAsync(long productId)
        {
            return await _context.Products.Include(c=>c.ProductComments).Include(c=>c.ProductCategories).ThenInclude(c=>c.Category)
                .Include(c => c.ProductFeatures).Include(c => c.ProductGalleries).AsQueryable()
                .Where(c=>c.Id==productId)
                .Select(c => new ProductDetailDto()
            {
                Category = c.ProductCategories.Select(c => c.Category).First(),
                Description = c.Description,
                Name = c.Name,
                Price = c.Price,
                ProductId = c.Id,
                ProductImageName = c.ProductImageName,
                ProductComment = c.ProductComments.Count(),
                    ProductFeatures = c.ProductFeatures.ToList(),
                ProductImages = c.ProductGalleries.Select(c => c.ImageName).ToList(),
                ShortDescription = c.ShortDescription,
            }).FirstOrDefaultAsync();
        }

        public async Task<List<ProductItemDto>> GetRelatedProduct(string cateName, long productId)
        {
            var product = await _context.Products.Include(c => c.ProductComments).Include(c => c.ProductCategories)
                .ThenInclude(c => c.Category).Where(c => c.ProductCategories.Any(c => c.Category.UrlName == cateName)
                && c.Id != productId).Take(6).ToListAsync();

            var data = product.Select(c => new ProductItemDto
            {
                Category = c.ProductCategories.Select(c => c.Category).First(),
                CommentCount = c.ProductComments.Count(),
                Price = c.Price,
                ProductId = c.Id,
                ProductImageName = c.ProductImageName,
                ProductName = c.Name
            }).ToList();

            return data;
        }


    }
}
