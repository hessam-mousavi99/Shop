﻿using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Admin.Product;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Contracts.Persistence.IRepositories.IProductEntities
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task SaveChangesAsync();
        Task<FilterProductsDto> FilterProducts(FilterProductsDto filterProductsDto);
    }
}