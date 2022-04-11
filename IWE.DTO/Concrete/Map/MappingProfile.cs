using AutoMapper;
using IWE.Entity.Concrete;

namespace IWE.DTO.Concrete.Map;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();
    }
}