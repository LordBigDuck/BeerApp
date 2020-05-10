using BeerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Core.Services
{
    public interface IBrewerService
    {
        /// <summary>
        /// Return all brewers with their beers and wholsaler selling them
        /// </summary>
        /// <returns></returns>
        Task<List<Brewer>> GetAllWithDetails();
    }
}
