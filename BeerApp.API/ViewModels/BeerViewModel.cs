using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.API.ViewModels
{
    public class BeerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double AlcoholLevel { get; set; }
        public BrewerViewModel Brewer { get; set; }
        public bool IsActive { get; set; }
    }
}
