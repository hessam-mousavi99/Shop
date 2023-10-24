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
    }
}
