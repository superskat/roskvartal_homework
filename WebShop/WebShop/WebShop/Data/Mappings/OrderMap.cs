using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShop.Models;

namespace WebShop.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasMany(x => x.items);
            builder.HasOne(x => x.person).WithMany(x => x.orders).HasForeignKey(x => x.personId);
        }
    }
}
