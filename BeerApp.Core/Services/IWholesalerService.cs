using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Core.Services
{
    public interface IWholesalerService
    {
        Task AddBeer(int wholesalerId, int beerId);
        Task UpdateStock(int wholesalerId, int beerId, int newStock);
    }
}
