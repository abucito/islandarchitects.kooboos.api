using AutoMapper;
using Kooboos.API.Base;
using Kooboos.API.Contexts;
using Kooboos.API.Units.Entities;
using Kooboos.API.Units.Models;

namespace Kooboos.API.Units
{
    public class UnitsRepository : BaseCrudRepository<Unit, UnitDto>, IUnitsRepository
    {
        public UnitsRepository(RecipeContext recipeContext, IMapper mapper) : base(recipeContext, mapper)
        {
        }
    }
}