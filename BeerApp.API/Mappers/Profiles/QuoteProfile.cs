using AutoMapper;
using BeerApp.API.ViewModels;
using BeerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.API.Mappers.Profiles
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Quote, GetQuoteViewModel.Quote>()
                .ForMember(
                    dest => dest.Items,
                    opt => opt.MapFrom(src => src.Items));
        }
    }
}
