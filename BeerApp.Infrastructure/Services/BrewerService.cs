using BeerApp.Core.Models;
using BeerApp.Core.Services;
using BeerApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Infrastructure.Services
{
    public class BrewerService : IBrewerService
    {
        private readonly BeerContext _context;

        public BrewerService(BeerContext context)
        {
            _context = context;
        }

        public async Task<List<Brewer>> GetAllWithDetails()
        {
            var brewers = await _context.Brewers
                .Include(brewer => brewer.Beers)
                    .ThenInclude(beer => beer.WholesalerBeers)
                    .ThenInclude(wholesalerBeer => wholesalerBeer.Wholesaler)
                .ToListAsync();

            foreach (var brewer in brewers)
            {
                brewer.Beers = brewer.Beers.Where(beer => beer.IsActive).ToList();
            }

            return brewers;
        }
    }
}
