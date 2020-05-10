using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Core.Models
{
    public class Brewer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Beer> Beers { get; set; }
    }
}
