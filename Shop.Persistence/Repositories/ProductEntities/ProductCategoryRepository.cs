using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Domain.Models.ProductEntities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.ProductEntities
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopDBContext _context;

        public ProductCategoryRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task addProductSelectedCategoryAsync(List<long> productSelectedCategories, long productId)
        {
            if (productSelectedCategories!=null && productSelectedCategories.Any())
            {
                var newSelected = new List<ProductCategory>();
                foreach (var categoryId in productSelectedCategories)
                {
                    newSelected.Add(new ProductCategory()
                    {
                        CategoryId = categoryId,
                        ProductId = productId
                    });
                }
                await _context.ProductCategories.AddRangeAsync(newSelected);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveProductSelectedCategoryAsync(long productId)
        {
            var allProductSelectedCategories = await _context.ProductCategories.AsQueryable().
                Where(pc => pc.ProductId == productId).ToListAsync();
            if (allProductSelectedCategories.Any())
            {
                _context.ProductCategories.RemoveRange(allProductSelectedCategories);
            }
        }
    }
}
