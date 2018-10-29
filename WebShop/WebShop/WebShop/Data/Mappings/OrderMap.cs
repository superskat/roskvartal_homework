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
            //products list
            builder.HasMany(x => x.items);
            //person
            builder.HasOne(x => x.person).WithMany(x => x.orders).HasForeignKey(x => x.personId);
            //discount
            builder.HasOne(x => x.giftCard).WithMany(x => x.orders).HasForeignKey(x => x.giftCardId);
            builder.HasOne(x => x.percentCard).WithMany(x => x.orders).HasForeignKey(x => x.percentCardId);
            builder.HasOne(x => x.sumSale).WithMany(x => x.orders).HasForeignKey(x => x.sumSaleId);
        }
    }
}
