using AutoMapper;
using BeerApp.API.ViewModels;
using BeerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.API.Mappers.Profiles
{
    public class BrewerProfile : Profile
    {
        public BrewerProfile()
        {
            CreateMap<Brewer, BrewerViewModel>();
            CreateMap<BrewerViewModel, Brewer>();
        }
    }
}
