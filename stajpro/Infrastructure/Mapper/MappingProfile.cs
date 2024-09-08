using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventsDto, Event>();
            CreateMap<UserForCreationDto, Users>();
            CreateMap<UserForUpdateDto, Users>().ReverseMap();
        }
    }
}