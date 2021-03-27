using System.Linq;
using AutoMapper;
using Data.DTOs;
using Data.Models;

namespace Services.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDetailDto>();
            CreateMap<User, UserDto>().ForPath(dest => dest.Contacts,
                mem => mem.MapFrom(u => u.Contacts.Select(uc => uc.Contact)));
        }
    }
}