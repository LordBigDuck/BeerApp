using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerApp.Core.Commands;
using BeerApp.Core.Models;
using BeerApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesalerController : ControllerBase
    {
        private readonly IWholesalerService _wholesalerService;

        public WholesalerController(
            IWholesalerService wholesalerService
            )
        {
            _wholesalerService = wholesalerService;
        }

        [HttpPost("{wholesalerId}/beer")]
        public async Task<ActionResult<Wholesaler>> AddBeer(AddBeerToWholesalerCommand command)
        {
            if (command == null) return BadRequest();

            await _wholesalerService.AddBeer(command);

            // TODO : Check to return a 201
            return Ok();
        }

        [HttpPut("{wholesalerId}/beer/{beerId}")]
        public async Task<ActionResult> UpdateBeerStock(int wholesalerId, int beerId, [FromBody] int stock)
        {
            await _wholesalerService.UpdateStock(new UpdateBeerStock
            {
                BeerId = beerId,
                WholesalerId = wholesalerId,
                Stock = stock
            });

            return Ok();
        }
    }
}