using AutoMapper;
using Kooboos.API.Entities;
using Kooboos.API.Models;

namespace Kooboos.API.AutomapperProfiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto, Ingredient>().ForMember(i => i.Id, id => id.Ignore());
            CreateMap<IngredientForCreationDto, IngredientDto>().ForMember(i => i.Id, id => id.Ignore());
            CreateMap<IngredientForUpdateDto, IngredientDto>().ForMember(i => i.Id, id => id.Ignore());
        }
    }
}