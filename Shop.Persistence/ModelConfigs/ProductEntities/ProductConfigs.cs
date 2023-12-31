﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.OrderEntities;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Persistence.ModelConfigs.ProductEntities
{
    public class ProductConfigs : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasMany<ProductGallery>(x => x.ProductGalleries).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany<ProductCategory>(x => x.ProductCategories).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany<ProductFeature>(x => x.ProductFeatures).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany<ProductComment>(x => x.ProductComments).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany<OrderDetail>(x => x.OrderDetails).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany<UserCompare>(x => x.UserCompares).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany<UserFavorite>(x => x.UserFavorites).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        }
    }
}
