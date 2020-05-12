using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeerApp.Core.Commands
{
    public class AddBeerCommand
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Only positive number allowed")]
        public double Price { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Only positive number allowed")]
        public double AlcoholLevel { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int BrewerId { get; set; }
    }
}
