using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingApp.DTOs;
using MeetingApp.Models;

namespace MeetingApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserForDetailsDTO>()
                .ForMember(dest =>  dest.PhotoUrl,opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(photo => photo.IsMain).url);
                })
                .ForMember(dest => dest.Age,
                opt => opt.ResolveUsing(d => d.DateOfBirth.GetAge()));

            CreateMap<Users, UserForListDTO>()
                .ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(photo => photo.IsMain).url)
                )
                .ForMember(dest => dest.Age,
                opt => opt.ResolveUsing(d => d.DateOfBirth.GetAge()));

            CreateMap<Photo, PhotoforDetailedDTO>();
        }
    }
}
