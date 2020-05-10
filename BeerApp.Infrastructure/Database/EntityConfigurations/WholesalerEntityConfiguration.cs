using BeerApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Infrastructure.Database.EntityConfigurations
{
    public class WholesalerEntityConfiguration : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.HasKey(w => w.Id);
        }
    }
}
