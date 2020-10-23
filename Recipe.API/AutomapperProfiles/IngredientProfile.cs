using AutoMapper;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.AutomapperProfiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<IngredientForCreationDto, IngredientDto>();
            CreateMap<IngredientForUpdateDto, IngredientDto>();
        }
    }
}