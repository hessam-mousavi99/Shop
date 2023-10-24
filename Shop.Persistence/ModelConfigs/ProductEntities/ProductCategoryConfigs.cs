using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Persistence.ModelConfigs.ProductEntities
{
    public class ProductCategoryConfigs : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasOne<Product>(x => x.Product).WithMany(x => x.ProductCategories);
            builder.HasOne<Category>(x => x.Category).WithMany(x => x.ProductCategories);
        }
    }
}
