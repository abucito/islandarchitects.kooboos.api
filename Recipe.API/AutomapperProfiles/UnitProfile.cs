using AutoMapper;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.AutomapperProfiles
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