using ABCTask.Core;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCTask.DTO
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Location, LocationDTO>()
                   .ForMember(dist => dist.City, opt => opt.MapFrom(src => src.City.Name)).ReverseMap();
            CreateMap<Location, LocationDTOPUT>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id)).ReverseMap();
            CreateMap<City, CityDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id)).ReverseMap();
            CreateMap<Location, LocationDTOPost>()
                .ForMember(d => d.CityId, o => o.MapFrom(s => s.CityId)).ReverseMap();
        }
    }
}
