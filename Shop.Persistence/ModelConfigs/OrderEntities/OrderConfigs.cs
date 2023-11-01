
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.OrderEntities;

namespace Shop.Persistence.ModelConfigs.OrderEntities
{
    public class OrderConfigs : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.HasOne<User>(x=>x.User).WithMany(x => x.Orders).HasForeignKey(x=>x.UserId);
            builder.HasMany<OrderDetail>(x => x.OrderDetails).WithOne(x => x.Order);
        }
    }
}
