using BeerApp.Core.Commands;
using BeerApp.Core.Exceptions;
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
            if (wholesaler == null) throw new CustomBadRequestException($"Wholesaler with id {command.WholesalerId} does not exist");

            var beer = _beerContext.Beers.FirstOrDefault(b => b.Id == command.BeerId);
            if (beer == null) throw new CustomBadRequestException($"Beer with id {command.BeerId} does not exist");

            if (wholesaler.WholesalerBeers.Any(wb => wb.BeerId == command.BeerId))
            {
                throw new CustomBadRequestException("Wholesaler already sell this beer");
            }

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
            if (command.CommandLines == null) throw new CustomBadRequestException("Item list cannot be null");

            if (command.CommandLines.Count() <= 0) throw new CustomBadRequestException("Item list cannot be null");

            // Duplicates
            var totalDistinct = command.CommandLines.Select(c => c.BeerId).Distinct().Count();
            if (command.CommandLines.Count() != totalDistinct)
            {
                throw new CustomBadRequestException("Item list cannot contains duplicates");
            }

            var wholesaler = await _beerContext.Wholesalers
                .Include(w => w.WholesalerBeers)
                    .ThenInclude(wb => wb.Beer)
                .SingleOrDefaultAsync(w => w.Id == id);
            if (wholesaler == null) throw new CustomBadRequestException($"Wholesaler does not exist");

            // Generate quote
            var quote = new Quote();
            foreach(var item in command.CommandLines)
            {
                var wb = wholesaler.WholesalerBeers.SingleOrDefault(wb => wb.BeerId == item.BeerId);
                if (wb == null)
                {
                    throw new CustomBadRequestException($"Beer with id: {item.BeerId} is not sell by this wholesaler");
                }

                if (wb.Stock < item.Quantity)
                {
                    throw new CustomBadRequestException($"Not enough stock for beer {item.BeerId}");
                }

                quote.Items.Add(new CommandLine
                {
                    Beer = wb.Beer,
                    Quantity = item.Quantity
                });
                quote.Total += item.Quantity * wb.Beer.Price;
            }

            // Apply discount
            quote.Total = Math.Round(quote.Total, 2);
            quote.Discount = quote.GetQuantityDiscount();
            quote.Price = quote.Total - quote.Discount;
            
            return quote;
        }

        public async Task UpdateStock(UpdateBeerStockCommand command)
        {
            if (command.Stock <= 0) throw new CustomBadRequestException("Stock should be positive");

            var wholesalerBeer = await _beerContext.WholesalerBeers
                .FindAsync(command.WholesalerId, command.BeerId);

            wholesalerBeer.Stock = command.Stock;
            _beerContext.Update(wholesalerBeer);

            await _beerContext.SaveChangesAsync();
        }
    }
}
