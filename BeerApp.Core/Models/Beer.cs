using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Core.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double AlcoholLevel { get; set; }
        public Brewer Brewer { get; set; }
        public ICollection<WholesalerBeer> WholesalerBeers { get; set; }

        // Used for soft delete
        public bool IsActive { get; set; }
    }
}
