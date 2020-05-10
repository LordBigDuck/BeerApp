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

        public void Add()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int beerId)
        {
            var beer = GetById(beerId);

            beer.IsActive = false;
            _context.Beers.Update(beer);

            return _context.SaveChangesAsync();
        }

        public Task<List<Beer>> GetAll()
        {
            return _context.Beers.ToListAsync();
        }

        public Beer GetById(int beerId)
        {
            var beer = _context.Beers.FirstOrDefault(beer => beer.Id == beerId);

            if (beer == null)
            {
                // TODO : throw custom not found exceptions
            }

            return beer;
        }
    }
}
