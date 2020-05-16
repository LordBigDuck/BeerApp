using BeerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerApp.Core.Commands
{
    public class GetQuoteCommand
    {
        public IEnumerable<BeerQuantity> CommandLines { get; set; }
    }

    public class BeerQuantity
    {
        public int BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
