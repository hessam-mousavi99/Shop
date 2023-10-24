using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Persistence.ModelConfigs.ProductEntities
{
    public class ProductGalleryConfigs : IEntityTypeConfiguration<ProductGallery>
    {
        public void Configure(EntityTypeBuilder<ProductGallery> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasOne<Product>(x => x.Product).WithMany(x => x.ProductGalleries);

        }
    }
}
