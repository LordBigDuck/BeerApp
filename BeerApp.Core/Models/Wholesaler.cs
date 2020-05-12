using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Core.Models
{
    public class Wholesaler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WholesalerBeer> WholesalerBeers { get; set; }

        public void AddBeer(Beer beer, int stock)
        {
            // TODO : do someting if stock is negative

            WholesalerBeers ??= new List<WholesalerBeer>();
            WholesalerBeers.Add(new WholesalerBeer
            {
                Wholesaler = this,
                Beer = beer,
                Stock = stock
            });
        }
    }
}
