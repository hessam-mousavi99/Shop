using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Domain.Models.ProductEntities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.ProductEntities
{
    public class ProductGalleryRepository : GenericRepository<ProductGallery>, IProductGalleryRepository
    {
        private readonly ShopDBContext _context;

        public ProductGalleryRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddProductGalleries(List<ProductGallery> productGalleries)
        {
            await _context.ProductGalleries.AddRangeAsync(productGalleries);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductGallery>> GetProductGalleriesAsync(long productId)
        {
            return await _context.ProductGalleries.AsQueryable().Where(c=>c.ProductId==productId).ToListAsync();
        }
    }
}
