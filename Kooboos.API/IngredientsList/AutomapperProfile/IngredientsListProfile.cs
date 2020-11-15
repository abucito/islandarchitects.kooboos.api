using AutoMapper;
using Kooboos.API.IngredientsLists.Entities;
using Kooboos.API.IngredientsLists.Models;

namespace Kooboos.API.IngredientsLists.AutomapperProfile
{
    public class IngredientsListProfile : Profile
    {
        public IngredientsListProfile()
        {
            CreateMap<IngredientsList, IngredientsListDto>().ForMember(dest => dest.IngredientsListItems, opts => opts.Ignore());
            CreateMap<IngredientsListItem, IngredientsListItemDto>()
                .ForMember(dest => dest.IngredientName, opts => opts.MapFrom(src => src.Ingredient.Name))
                .ForMember(dest => dest.UnitName, opts => opts.MapFrom(src => src.Unit.Name));
            CreateMap<IngredientsListItemForCreationDto, IngredientsListItem>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.IngredientsListId, opts => opts.Ignore())
                .ForMember(dest => dest.IngredientsList, opts => opts.Ignore())
                .ForMember(dest => dest.Unit, opts => opts.Ignore())
                .ForMember(dest => dest.Ingredient, opts => opts.Ignore());
        }
    }
}