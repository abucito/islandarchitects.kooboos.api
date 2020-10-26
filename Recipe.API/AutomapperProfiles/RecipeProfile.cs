using AutoMapper;
using Recipe.API.Models;

namespace Recipe.API.AutomapperProfiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<RecipeForCreationDto, RecipeDto>().ForMember(r => r.Id, id => id.Ignore());
            CreateMap<RecipeForUpdateDto, RecipeDto>().ForMember(r => r.Id, id => id.Ignore());
            CreateMap<Entities.Recipe, RecipeDto>();
            CreateMap<RecipeDto, Entities.Recipe>().ForMember(r => r.Id, id => id.Ignore()).ForMember(r => r.IngredientsList, il => il.Ignore());
        }
    }
}