using BeerApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Infrastructure.Database.EntityConfigurations
{
    public class BrewerEntityConfiguration : IEntityTypeConfiguration<Brewer>
    {
        public void Configure(EntityTypeBuilder<Brewer> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasMany(b => b.Beers)
                .WithOne(b => b.Brewer);
        }
    }
}
