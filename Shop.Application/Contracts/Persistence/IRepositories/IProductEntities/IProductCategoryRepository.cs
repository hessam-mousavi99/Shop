﻿using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Contracts.Persistence.IRepositories.IProductEntities
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
    }
}
