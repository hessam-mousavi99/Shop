using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Site;

namespace Shop.Persistence.ModelConfigs.Site
{
    public class SliderConfigs : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasQueryFilter(x => x.IsDelete == false);
        }
    }
}
