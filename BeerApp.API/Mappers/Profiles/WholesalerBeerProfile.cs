using AutoMapper;
using BeerApp.API.ViewModels;
using BeerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.API.Mappers.Profiles
{
    public class WholesalerBeerProfile : Profile
    {
        public WholesalerBeerProfile()
        {
            CreateMap<WholesalerBeer, GetBrewerDetails.Wholesaler>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.WholesalerId))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Wholesaler.Name))
                .ForMember(
                    dest => dest.Stock,
                    opt => opt.MapFrom(src => src.Stock));
        }
    }
}
