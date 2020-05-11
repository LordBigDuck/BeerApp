using BeerApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Infrastructure.Database
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brewer>().HasData(new
            {
                Id = 1,
                Name = "Abbaye de Leffe"
            });

            modelBuilder.Entity<Beer>().HasData(new
            {
                Id = 1,
                Name = "Leffe Blonde",
                Price = 2.2,
                AlcoholLevel = 6.6,
                IsActive = true,
                BrewerId = 1
            }, 
            new
            {
                Id = 2,
                Name = "Leffe Brune",
                Price = 2.8,
                AlcoholLevel = 8.6,
                IsActive = true,
                BrewerId = 1
            });

            modelBuilder.Entity<Brewer>().HasData(new
            {
                Id = 2,
                Name = "Achouffe"
            });

            modelBuilder.Entity<Beer>().HasData(new
            {
                Id = 3,
                Name = "Chouffe",
                Price = 3.1,
                AlcoholLevel = 7.5,
                IsActive = true,
                BrewerId = 2
            });

            modelBuilder.Entity<Brewer>().HasData(new
            {
                Id = 3,
                Name = "Abbaye Notre-Dame de Scourmont"
            });

            modelBuilder.Entity<Beer>().HasData(new
            {
                Id = 4,
                Name = "Chimay Bleue",
                Price = 3.0,
                AlcoholLevel = 8.8,
                IsActive = true,
                BrewerId = 3
            }, new
            {
                Id = 5,
                Name = "Chimay Brune",
                Price = 2.8,
                AlcoholLevel = 7.9,
                IsActive = true,
                BrewerId = 3
            });

            // Wholesalers
            modelBuilder.Entity<Wholesaler>().HasData(new
            {
                Id = 1,
                Name = "HappyHour"
            }, new
            {
                Id = 2,
                Name = "GetDrunk"
            });

            modelBuilder.Entity<WholesalerBeer>().HasData(new
            {
                WholesalerId = 1,
                BeerId = 1,
                Stock = 38
            }, new
            {
                WholesalerId = 2,
                BeerId = 1,
                Stock = 12
            }, new
            {
                WholesalerId = 1,
                BeerId = 2,
                Stock = 18
            }, new
            {
                WholesalerId = 2,
                BeerId = 2,
                Stock = 21
            }, new
            {
                WholesalerId = 1,
                BeerId = 3,
                Stock = 5
            }, new
            {
                WholesalerId = 2,
                BeerId = 4,
                Stock = 12
            }, new
            {
                WholesalerId = 2,
                BeerId = 3,
                Stock = 18
            }, new
            {
                WholesalerId = 1,
                BeerId = 5,
                Stock = 16
            });
        }
    }
}
