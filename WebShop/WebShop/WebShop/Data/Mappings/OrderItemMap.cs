using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Mappings
{
    public class OrderItemMap: IEntityTypeConfiguration<Models.OrderItem>
    {
        public void Configure(EntityTypeBuilder<Models.OrderItem> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasOne(x => x.order).WithMany(x => x.items).HasForeignKey(x => x.orderId);
            builder.HasOne(x => x.product).WithMany(x => x.orderItems).HasForeignKey(x => x.productId);
        }
    }
}
