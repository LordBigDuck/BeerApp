using AutoMapper;
using BeerApp.API.ViewModels;
using BeerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.API.Mappers.Profiles
{
    public class CommandLineProfile : Profile
    {
        public CommandLineProfile()
        {
            CreateMap<CommandLine, GetQuoteViewModel.CommandLine>()
                .ForMember(
                    dest => dest.Beer,
                    opt => opt.MapFrom(src => src.Beer));
        }
    }
}
