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
            CreateMap<Beer, GetBeer.Beer>()
                .ForMember(
                    dest => dest.Brewer,
                    opt => opt.MapFrom(src => src.Brewer));

            CreateMap<Beer, GetBrewerDetails.Beer>()
                .ForMember(
                    dest => dest.Wholesalers,
                    opt => opt.MapFrom(src => src.WholesalerBeers));

            CreateMap<Beer, GetQuoteViewModel.Beer>();

        }
    }
}
