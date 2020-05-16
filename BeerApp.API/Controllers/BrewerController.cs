using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeerApp.API.ViewModels;
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
        private readonly IMapper _mapper;

        public BrewerController(
            IBrewerService brewerService,
            IMapper mapper)
        {
            _brewerService = brewerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetBrewerDetails>>> GetAllBrewersWithBeers()
        {
            
            var brewers = await _brewerService.GetAllWithDetails();

            var brewerViewModelList = _mapper.Map<List<Brewer>, List<GetBrewerDetails.Brewer>>(brewers);

            return Ok(brewerViewModelList);
        }
    }
}