using BeerApp.Core.Commands;
using BeerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Core.Services
{
    public interface IWholesalerService
    {
        Task AddBeer(AddBeerToWholesalerCommand command);
        Task<Wholesaler> GetById(int id);
        Task<Quote> GetQuote(int id, GetQuoteCommand command);
        Task UpdateStock(UpdateBeerStockCommand command);
    }
}
