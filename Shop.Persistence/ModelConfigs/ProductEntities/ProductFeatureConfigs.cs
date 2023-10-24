using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Persistence.ModelConfigs.ProductEntities
{
    public class ProductFeatureConfigs : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasOne<Product>(x => x.Product).WithMany(x => x.ProductFeatures);
        }
    }
}
