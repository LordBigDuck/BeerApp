using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Core.Commands
{
    public class UpdateBeerStock
    {
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        public int Stock { get; set; }
    }
}
