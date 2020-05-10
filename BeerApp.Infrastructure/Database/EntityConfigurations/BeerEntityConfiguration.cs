using BeerApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Infrastructure.Database.EntityConfigurations
{
    public class BeerEntityConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Brewer)
                .WithMany(b => b.Beers);
        }
    }
}
