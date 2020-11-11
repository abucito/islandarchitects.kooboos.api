using AutoMapper;
using Kooboos.API.Recipes.Models;

namespace Kooboos.API.Recipes.AutomapperProfile
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            IMappingExpression<RecipeForCreationDto, RecipeDto> mappingExpression = CreateMap<RecipeForCreationDto, RecipeDto>().ForMember(r => r.Id, id => id.Ignore());
            CreateMap<RecipeForUpdateDto, RecipeDto>().ForMember(r => r.Id, id => id.Ignore());
            CreateMap<Entities.Recipe, RecipeDto>();
            CreateMap<RecipeDto, Entities.Recipe>().ForMember(r => r.Id, id => id.Ignore()).ForMember(r => r.IngredientsList, il => il.Ignore());
        }
    }
}