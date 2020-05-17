using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeerApp.API.ViewModels;
using BeerApp.Core.Commands;
using BeerApp.Core.Exceptions;
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
        private readonly IMapper _mapper;

        public WholesalerController(
            IWholesalerService wholesalerService,
            IMapper mapper
            )
        {
            _wholesalerService = wholesalerService;
            _mapper = mapper;
        }

        [HttpPost("{wholesalerId}/quote")]
        public async Task<ActionResult<GetQuoteViewModel>> GetQuote(int wholesalerId, GetQuoteCommand command)
        {
            var quote = await _wholesalerService.GetQuote(wholesalerId, command);

            var quoteViewModel = _mapper.Map<Quote, GetQuoteViewModel.Quote>(quote);

            return Ok(quoteViewModel);
        } 

        [HttpPost("{wholesalerId}/beer")]
        public async Task<ActionResult<Wholesaler>> AddBeer(AddBeerToWholesalerCommand command)
        {
            await _wholesalerService.AddBeer(command);

            // TODO : Check to return a 201
            return Ok();
        }

        [HttpPut("{wholesalerId}/beer/{beerId}")]
        public async Task<ActionResult> UpdateBeerStock(int wholesalerId, int beerId, [FromBody] int stock)
        {
            await _wholesalerService.UpdateStock(new UpdateBeerStockCommand
            {
                BeerId = beerId,
                WholesalerId = wholesalerId,
                Stock = stock
            });

            return Ok();
        }
    }
}