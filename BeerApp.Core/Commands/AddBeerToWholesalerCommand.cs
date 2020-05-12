using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeerApp.Core.Commands
{
    public class AddBeerToWholesalerCommand
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int WholesalerId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int BeerId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Stock { get; set; } = 0;
    }
}
