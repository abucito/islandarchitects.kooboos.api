using AutoMapper;
using Recipe.API.Models;

namespace Recipe.API.AutomapperProfiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<RecipeForCreationDto, RecipeDto>();
            CreateMap<RecipeForUpdateDto, RecipeDto>();
            CreateMap<Entities.Recipe, RecipeDto>().ReverseMap();
        }
    }
}