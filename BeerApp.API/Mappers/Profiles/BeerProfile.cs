using AutoMapper;
using BeerApp.API.ViewModels;
using BeerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.API.Mappers.Profiles
{
    public class BeerProfile : Profile
    {
        public BeerProfile()
        {
            CreateMap<Beer, BeerViewModel>();
            CreateMap<BeerViewModel, Beer>();
        }
    }
}
