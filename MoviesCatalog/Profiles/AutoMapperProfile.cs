using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MoviesCatalog.Models;
using MoviesCatalog.ViewModels;

namespace MoviesCatalog.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieViewModel>()
                .ForMember(x => x.Description, x => x.MapFrom(y => y.Description))
                .ForMember(x => x.Year, x => x.MapFrom(y => y.Year))
                .ForMember(x => x.Title, x => x.MapFrom(y => y.Title))
                .ForMember(x => x.Date, x => x.MapFrom(y => y.AddDate))
                .ReverseMap();

            CreateMap<Movie, EditViewModel>()
               .ForMember(x => x.Description, x => x.MapFrom(y => y.Description))
               .ForMember(x => x.Year, x => x.MapFrom(y => y.Year))
               .ForMember(x => x.Title, x => x.MapFrom(y => y.Title))
               .ForMember(x => x.EditDate, x => x.MapFrom(y => y.AddDate))
               .ReverseMap();
        }
    }
}
