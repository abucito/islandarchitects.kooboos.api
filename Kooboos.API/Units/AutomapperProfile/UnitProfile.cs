using AutoMapper;
using Kooboos.API.Units.Entities;
using Kooboos.API.Units.Models;

namespace Kooboos.API.Units.AutomapperProfile
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