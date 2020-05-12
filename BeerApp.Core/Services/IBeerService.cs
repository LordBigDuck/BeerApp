using BeerApp.Core.Commands;
using BeerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Core.Services
{
    public interface IBeerService
    {
        Beer Add(AddBeerCommand command);
        Task<List<Beer>> GetAll();
        Task<Beer> GetById(int beerId);
        Task Delete(int beerId);
    }
}
