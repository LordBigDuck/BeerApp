using BeerApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Infrastructure.Services
{
    public class WholesalerService : IWholesalerService
    {
        public Task AddBeer(int wholesalerId, int beerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStock(int wholesalerId, int beerId, int newStock)
        {
            throw new NotImplementedException();
        }
    }
}
