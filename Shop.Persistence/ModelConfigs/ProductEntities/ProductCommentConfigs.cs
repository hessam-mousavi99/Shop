using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.ProductEntities;
using Shop.Domain.Models.Account;

namespace Shop.Persistence.ModelConfigs.ProductEntities
{
    public class ProductCommentConfigs : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasOne<Product>(x => x.Product).WithMany(x => x.ProductComments);
            builder.HasOne<User>(x => x.User).WithMany(x => x.ProductComments);
        }
    }
}
