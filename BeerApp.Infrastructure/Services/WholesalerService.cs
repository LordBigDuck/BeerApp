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

        // Dans l'enonce, "Le brasseur doit exister" => que quoi?
        public async Task<Quote> GetQuote(int id, GetQuoteCommand command)
        {
            // Empty command
            if (command.CommandLines == null) throw new Exception("Item list cannot be null");

            if (command.CommandLines.Count() <= 0) throw new Exception("Item list cannot be null");

            // Duplicates
            if (command.CommandLines.Count() != command.CommandLines.Distinct().Count())
            {
                throw new Exception("Item list cannot contains duplicates");
            }

            var wholesaler = await _beerContext.Wholesalers
                .Include(w => w.WholesalerBeers)
                    .ThenInclude(wb => wb.Beer)
                .SingleOrDefaultAsync(w => w.Id == id);

            // Generate quote
            var quote = new Quote();
            foreach(var item in command.CommandLines)
            {
                var wb = wholesaler.WholesalerBeers.SingleOrDefault(wb => wb.BeerId == item.BeerId);
                if (wb == null)
                {
                    throw new Exception($"Beer with id: {item.BeerId} is not sell by this wholesaler");
                }

                quote.Items.Add(new CommandLine
                {
                    Beer = wb.Beer,
                    Quantity = item.Quantity
                });
                quote.Price += item.Quantity * wb.Beer.Price;
            }

            // Apply discount
            var discount = quote.GetQuantityDiscount();
            quote.Price -= discount;
            quote.Price = Math.Round(quote.Price, 2);

            return quote;
        }

        public async Task UpdateStock(UpdateBeerStockCommand command)
        {
            if (command.Stock <= 0) throw new Exception("Stock should be positive");

            var wholesalerBeer = await _beerContext.WholesalerBeers
                .FindAsync(command.WholesalerId, command.BeerId);

            wholesalerBeer.Stock = command.Stock;
            _beerContext.Update(wholesalerBeer);

            await _beerContext.SaveChangesAsync();
        }
    }
}
