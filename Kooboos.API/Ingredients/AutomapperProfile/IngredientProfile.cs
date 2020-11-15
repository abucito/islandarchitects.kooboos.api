using AutoMapper;
using Kooboos.API.Ingredients.Entities;
using Kooboos.API.Ingredients.Models;

namespace Kooboos.API.Ingredients.AutomapperProfile
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