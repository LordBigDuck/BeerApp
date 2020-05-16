using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.API.ViewModels
{
    public class GetBeer
    {
        internal class Beer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public double AlcoholLevel { get; set; }
            public Brewer Brewer { get; set; }
        }

        internal class Brewer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
