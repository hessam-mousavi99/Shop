using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        }
    }
}
