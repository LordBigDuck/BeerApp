using BeerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Core.Services
{
    public interface IBeerService
    {
        void Add();
        Task<List<Beer>> GetAll();
        Beer GetById(int beerId);
        Task Delete(int beerId);
    }
}
