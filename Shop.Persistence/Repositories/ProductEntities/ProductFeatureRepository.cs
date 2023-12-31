﻿using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Domain.Models.ProductEntities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Generics;

namespace Shop.Persistence.Repositories.ProductEntities
{
    public class ProductFeatureRepository : GenericRepository<ProductFeature>, IProductFeatureRepository
    {
        private readonly ShopDBContext _context;

        public ProductFeatureRepository(ShopDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProductFeature>> GetProductFeaturesAsync(long productId)
        {
            return await _context.ProductFeatures.Where(f => f.ProductId == productId).ToListAsync();
        }
    }
}
