using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.API.ViewModels
{
    public class GetBrewerDetails
    {
        internal class Brewer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<Beer> Beers { get; set; }
        }

        internal class Beer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public double AlcoholLevel { get; set; }
            public ICollection<Wholesaler> Wholesalers { get; set; }
        }

        internal class Wholesaler
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Stock { get; set; }
        }
    }
}
