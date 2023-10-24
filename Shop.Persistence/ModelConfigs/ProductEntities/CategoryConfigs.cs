using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Persistence.ModelConfigs.ProductEntities
{
    public class CategoryConfigs : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasMany<Category>(p => p.Categories).WithOne(p => p.ParentCategory).HasForeignKey(p => p.ParentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany<ProductCategory>(p => p.ProductCategories).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
        }
    }
}
