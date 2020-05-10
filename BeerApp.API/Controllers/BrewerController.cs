using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerApp.Core.Models;
using BeerApp.Core.Services;
using BeerApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrewerController : ControllerBase
    {
        private readonly IBrewerService _brewerService;

        public BrewerController(IBrewerService brewerService)
        {
            _brewerService = brewerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Brewer>>> GetAllBrewersWithBeers()
        {
            
            var brewers = await _brewerService.GetAllWithDetails();

            return Ok(brewers);
        }
    }
}