using AutoMapper;
using Kooboos.API.Entities;
using Kooboos.API.Models;

namespace Kooboos.API.AutomapperProfiles
{
    public class IngredientsListProfile : Profile
    {
        public IngredientsListProfile()
        {
            CreateMap<IngredientsList, IngredientsListDto>().ForMember(dest => dest.IngredientsListItems, opts => opts.Ignore());
            CreateMap<IngredientsListItem, IngredientsListItemDto>()
                .ForMember(dest => dest.IngredientName, opts => opts.MapFrom(src => src.Ingredient.Name))
                .ForMember(dest => dest.UnitName, opts => opts.MapFrom(src => src.Unit.Name));

            CreateMap<IngredientsListItemForCreationDto, IngredientsListItemDto>()
                .ForMember(dest => dest.IngredientName, opts => opts.Ignore())
                .ForMember(dest => dest.UnitName, opts => opts.Ignore());
        }
    }
}