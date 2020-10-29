using System.Collections.Generic;
using AutoMapper;
using Kooboos.API.Base;
using Kooboos.API.Contexts;
using Kooboos.API.Entities;
using Kooboos.API.Models;

namespace Kooboos.API.Units
{
    public class UnitsRepository : BaseCrudRepository<Unit, UnitDto>, IUnitsRepository
    {
        public UnitsRepository(RecipeContext recipeContext, IMapper mapper) : base(recipeContext, mapper)
        {
        }
    }
}