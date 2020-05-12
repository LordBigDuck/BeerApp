using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.API.ViewModels
{
    public class WholesalerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BeerViewModel> Beers { get; set; }
    }
}
