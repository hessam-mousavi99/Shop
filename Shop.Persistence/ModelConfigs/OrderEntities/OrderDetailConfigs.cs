
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.OrderEntities;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Persistence.ModelConfigs.OrderEntities
{
    public class OrderDetailConfigs : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasOne<Order>(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            builder.HasOne<Product>(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductId);
        }
    }
}

