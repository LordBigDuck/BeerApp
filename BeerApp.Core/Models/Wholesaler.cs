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
    }
}
