using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Mappings
{
    public class GiftCardMap: IEntityTypeConfiguration<Models.Discount.GiftCard>
    {
        public void Configure(EntityTypeBuilder<Models.Discount.GiftCard> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasMany(x => x.orders);
        }
    }
}
