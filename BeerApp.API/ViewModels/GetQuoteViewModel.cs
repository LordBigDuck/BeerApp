using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.API.ViewModels
{
    public class GetQuoteViewModel
    {
        internal class Quote
        {
            public double Total { get; set; }
            public double Discount { get; set; }
            public double Price { get; set; }
            public List<CommandLine> Items { get; set; }
        }

        internal class CommandLine
        {
            public Beer Beer { get; set; }
            public int Quantity { get; set; }
        }
        
        internal class Beer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public double AlcoholLevel { get; set; }
        }
    }
}
