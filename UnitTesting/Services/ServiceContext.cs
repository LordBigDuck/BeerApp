using BeerApp.Core.Models;
using BeerApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting.Services
{
    public class ServiceContext
    {
        protected DbContextOptions<BeerContext> ContextOptions { get; }

        protected ServiceContext(DbContextOptions<BeerContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        private void Seed()
        {
            
        }
    }
}
