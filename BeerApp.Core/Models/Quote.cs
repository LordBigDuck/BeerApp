using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace BeerApp.Core.Models
{
    public class Quote
    {
        public double Total { get; set; } = 0;
        public double Discount { get; set; } = 0;
        public double Price { get; set; } = 0;
        public List<CommandLine> Items { get; set; } = new List<CommandLine>();

        public double GetQuantityDiscount()
        {
            var totalQuantity = 0;
            foreach(var item in Items)
            {
                totalQuantity += item.Quantity;
            }

            // Dans l'enonce, il est mis AU DESSUS de x. Mais il est plus logique que la reduction se fasse 
            // a partir d'un chiffre rond, d'ou le plus >= et non pas >
            double discount = 0;
            if (totalQuantity >= 10 && totalQuantity < 20)
            {
                discount = Total * 0.1;
            } 
            else if (totalQuantity >= 20)
            {
                discount = Total * 0.2;
            }

            return Math.Round(discount, 2);
        }
    }
}
