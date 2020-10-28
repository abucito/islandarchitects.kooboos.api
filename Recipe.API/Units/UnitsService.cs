using System.Collections.Generic;
using Recipe.API.Base;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Units
{
    public class UnitsService : BaseCrudService<Unit, UnitDto>, IUnitsService
    {
        public UnitsService(IUnitsRepository unitsRepository) : base(unitsRepository)
        {
        }
    }
}