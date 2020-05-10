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

            // Brewers
            //var brewer1 = new Brewer
            //{
            //    Id = 1,
            //    Name = "Abbaye de Leffe",
            //    Beers = new List<Beer>()
            //};
            //var brewer2 = new Brewer
            //{
            //    Id = 2,
            //    Name = "Achouffe",
            //    Beers = new List<Beer>()
            //};
            //var brewer3 = new Brewer
            //{
            //    Id = 3,
            //    Name = "Abbaye Notre-Dame de Scourmont",
            //    Beers = new List<Beer>()
            //};

            // Beers
            //var beer1 = new Beer
            //{
            //    Id = 1,
            //    Name = "Leffe Blonde",
            //    Price = 2.2,
            //    AlcoholLevel = 6.6,
            //    BrewerId = 1
            //};
            //modelBuilder.Entity<Beer>().HasData(beer1);
            //var beer2 = new Beer
            //{
            //    Id = 2,
            //    Name = "Leffe Brune",
            //    Price = 2.8,
            //    AlcoholLevel = 8.6,
            //    Brewer = brewer1
            //};
            //var beer3 = new Beer
            //{
            //    Id = 3,
            //    Name = "Chouffe",
            //    Price = 3.1,
            //    AlcoholLevel = 7.5,
            //    Brewer = brewer2
            //};
            //var beer4 = new Beer
            //{
            //    Id = 4,
            //    Name = "Chimay Bleue",
            //    Price = 3.0,
            //    AlcoholLevel = 8.8,
            //    Brewer = brewer3
            //};
            //var beer5 = new Beer
            //{
            //    Id = 5,
            //    Name = "Chimay Brune",
            //    Price = 2.8,
            //    AlcoholLevel = 7.9,
            //    Brewer = brewer3
            //};

            //brewer1.Beers.Add(beer1);
            //brewer1.Beers.Add(beer2);
            //brewer2.Beers.Add(beer3);
            //brewer3.Beers.Add(beer4);
            //brewer3.Beers.Add(beer5);

            // Wholesalers
            //var wholesaler1 = new Wholesaler
            //{
            //    Id = 1,
            //    Name = "HappyHour"
            //};
            //var wholesaler2 = new Wholesaler
            //{
            //    Id = 2,
            //    Name = "GetDrunk"
            //};

            // WholesalerBeer
            //var wholesalerBeer1 = new WholesalerBeer
            //{
            //    WholesalerId = 1,
            //    Wholesaler = wholesaler1,
            //    Beer = beer1,
            //    BeerId = 1,
            //    Stock = 38
            //};
            //var wholesalerBeer2 = new WholesalerBeer
            //{
            //    WholesalerId = 2,
            //    Wholesaler = wholesaler2,
            //    Beer = beer1,
            //    BeerId = 1,
            //    Stock = 12
            //};
            //var wholesalerBeer3 = new WholesalerBeer
            //{
            //    WholesalerId = 1,
            //    Wholesaler = wholesaler1,
            //    Beer = beer2,
            //    BeerId = 2,
            //    Stock = 18
            //};
            //var wholesalerBeer4 = new WholesalerBeer
            //{
            //    WholesalerId = 2,
            //    Wholesaler = wholesaler2,
            //    Beer = beer2,
            //    BeerId = 2,
            //    Stock = 21
            //};
            //var wholesalerBeer5 = new WholesalerBeer
            //{
            //    WholesalerId = 1,
            //    Wholesaler = wholesaler1,
            //    Beer = beer3,
            //    BeerId = 3,
            //    Stock = 5
            //};
            //var wholesalerBeer6 = new WholesalerBeer
            //{
            //    WholesalerId = 2,
            //    Wholesaler = wholesaler2,
            //    Beer = beer4,
            //    BeerId = 4,
            //    Stock = 12
            //};
            //var wholesalerBeer7 = new WholesalerBeer
            //{
            //    WholesalerId = 1,
            //    Wholesaler = wholesaler1,
            //    Beer = beer5,
            //    BeerId = 5,
            //    Stock = 16
            //};

            //modelBuilder.Entity<Brewer>().HasData(brewer1, brewer2, brewer3);
            //modelBuilder.Entity<Beer>().HasData(beer1, beer2, beer3, beer4, beer5);
            //modelBuilder.Entity<Wholesaler>().HasData(wholesaler1, wholesaler2);
            //modelBuilder.Entity<WholesalerBeer>().HasData(wholesalerBeer1, wholesalerBeer2, wholesalerBeer3, wholesalerBeer4, 
            //    wholesalerBeer5, wholesalerBeer6, wholesalerBeer7);
        }
    }
}
