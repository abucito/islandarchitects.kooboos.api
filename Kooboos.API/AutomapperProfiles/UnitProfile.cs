using AutoMapper;
using Kooboos.API.Entities;
using Kooboos.API.Models;

namespace Kooboos.API.AutomapperProfiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<UnitDto, Unit>().ForMember(i => i.Id, id => id.Ignore());
            CreateMap<UnitForCreationDto, UnitDto>().ForMember(i => i.Id, id => id.Ignore());
            CreateMap<UnitForUpdateDto, UnitDto>().ForMember(i => i.Id, id => id.Ignore());
        }
    }
}