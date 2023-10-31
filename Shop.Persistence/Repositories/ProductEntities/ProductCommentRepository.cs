using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Domain.Models.ProductEntities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.ProductEntities
{
    public class ProductCommentRepository : GenericRepository<ProductComment>, IProductCommentRepository
    {
        private readonly ShopDBContext _context;
        public ProductCommentRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProductComment>> GetAllCommentsByIdAsync(long productId)
        {
            return await _context.ProductComments.AsQueryable().Where(c => c.ProductId == productId).ToListAsync();
        }
    }
}
