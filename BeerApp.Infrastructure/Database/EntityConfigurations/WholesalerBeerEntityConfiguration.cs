using BeerApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Infrastructure.Database.EntityConfigurations
{
    public class WholesalerBeerEntityConfiguration : IEntityTypeConfiguration<WholesalerBeer>
    {
        public void Configure(EntityTypeBuilder<WholesalerBeer> builder)
        {
            builder.HasKey(wb => new { wb.BeerId, wb.WholesalerId });

            builder.HasOne(wb => wb.Beer)
                .WithMany(b => b.WholesalerBeers)
                .HasForeignKey(wb => wb.BeerId);

            builder.HasOne(wb => wb.Wholesaler)
                .WithMany(w => w.WholesalerBeers)
                .HasForeignKey(wb => wb.WholesalerId);
        }
    }
}
