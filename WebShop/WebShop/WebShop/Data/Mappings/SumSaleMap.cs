using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Mappings
{
    public class SumSaleMap : IEntityTypeConfiguration<Models.Discount.SumSale>
    {
        public void Configure(EntityTypeBuilder<Models.Discount.SumSale> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasMany(x => x.orders);
        }
    }
}
