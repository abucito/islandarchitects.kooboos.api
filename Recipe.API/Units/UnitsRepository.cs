using System.Collections.Generic;
using AutoMapper;
using Recipe.API.Base;
using Recipe.API.Contexts;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Units
{
    public class UnitsRepository : BaseCrudRepository<Unit, UnitDto>, IUnitsRepository
    {
        public UnitsRepository(RecipeContext recipeContext, IMapper mapper) : base(recipeContext, mapper)
        {
        }
    }
}