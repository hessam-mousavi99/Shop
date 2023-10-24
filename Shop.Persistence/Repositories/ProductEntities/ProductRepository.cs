using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
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
    }
}
