using BeerApp.Core.Commands;
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
    public class BeerService : IBeerService
    {
        private readonly BeerContext _context;

        public BeerService(BeerContext context)
        {
            _context = context;
        }

        // Note: trying to not use async version of SaveChanges
        // Note 2 : trying Single instead of SingleOrDefault
        public Beer Add(AddBeerCommand command)
        {
            // Check if brasseur exist
            // check if exception throw is null is enough
            var brewer = _context.Brewers.Single(brewer => brewer.Id == command.BrewerId);

            var beer = new Beer
            {
                AlcoholLevel = command.AlcoholLevel,
                Name = command.Name,
                Price = command.Price,
                IsActive = true,
                Brewer = brewer
            };

            _context.Beers.Add(beer);
            _context.SaveChanges();

            return beer;
        }

        public async Task Delete(int beerId)
        {
            var beer = await GetById(beerId);

            // TODO return custom exception
            if (beer == null) throw new Exception("No beer found");

            beer.IsActive = false;
            _context.Beers.Update(beer);

            await _context.SaveChangesAsync();
        }

        public Task<List<Beer>> GetAll()
        {
            return _context.Beers.ToListAsync();
        }

        public Task<Beer> GetById(int beerId)
        {
            return _context.Beers
                .Include(beer => beer.Brewer)
                .FirstOrDefaultAsync(beer => beer.Id == beerId);
        }
    }
}
