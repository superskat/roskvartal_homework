using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Mappings
{
    public class PercentCardMap : IEntityTypeConfiguration<Models.Discount.PercentCard>
    {
        public void Configure(EntityTypeBuilder<Models.Discount.PercentCard> builder)
        {
            builder.HasKey(x => x.id);
        }
    }
}
