using BeerApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BeerApp.Infrastructure.Database
{
    public class BeerContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<Brewer> Brewers { get; set; }
        public DbSet<WholesalerBeer> WholesalerBeers { get; set; }

        public BeerContext(DbContextOptions<BeerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }
    }
}
