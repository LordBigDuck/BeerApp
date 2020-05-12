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
    public class WholesalerService : IWholesalerService
    {
        private readonly BeerContext _beerContext;

        public WholesalerService(BeerContext beerContext)
        {
            _beerContext = beerContext;
        }

        public Task AddBeer(AddBeerToWholesalerCommand command)
        {
            var wholesaler = _beerContext.Wholesalers
                .Include(w => w.WholesalerBeers)
                .FirstOrDefault(w => w.Id == command.WholesalerId);
            if (wholesaler == null) throw new Exception("TODO : return custom message");

            var beer = _beerContext.Beers.FirstOrDefault(b => b.Id == command.BeerId);
            if (beer == null) throw new Exception("TODO : return custom message");

            // TODO : when wholesaler already contains beer, check if return custom excption or custom one
            //if (wholesaler.WholesalerBeers.Any(wb => wb.BeerId == command.BeerId)) throw new Exception("TODO : return custom message");

            wholesaler.AddBeer(beer, command.Stock);
            _beerContext.Wholesalers.Update(wholesaler);
            return _beerContext.SaveChangesAsync();
        }

        public Task<Wholesaler> GetById(int id)
        {
            return _beerContext.Wholesalers.FirstOrDefaultAsync(w => w.Id == id);
        }

        public Task<object> GetQuote()
        {
            throw new NotImplementedException();
        }

        public Task UpdateStock(UpdateBeerStock command)
        {
            throw new NotImplementedException();
        }
    }
}
