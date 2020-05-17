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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BeerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;
        private readonly IMapper _mapper;

        public BeerController(
            IBeerService beerService,
            IMapper mapper)
        {
            _beerService = beerService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBeer>> GetById(int id)
        {
            var beer = await _beerService.GetById(id);

            if (beer == null) throw new CustomNotFoundException($"Beer with id {id} does not exist");

            var beerViewModel = _mapper.Map<GetBeer.Beer>(beer);
            return Ok(beerViewModel);
        }

        [HttpPost]
        public ActionResult<GetBeer> Add([FromBody] AddBeerCommand command)
        {
            var beer = _beerService.Add(command);

            return CreatedAtAction(nameof(GetById), new { id = beer.Id }, _mapper.Map<GetBeer.Beer>(beer));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _beerService.Delete(id);

            return NoContent();
        }
    }
}