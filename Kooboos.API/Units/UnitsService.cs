using System.Collections.Generic;
using Kooboos.API.Base;
using Kooboos.API.Entities;
using Kooboos.API.Models;

namespace Kooboos.API.Units
{
    public class UnitsService : BaseCrudService<Unit, UnitDto>, IUnitsService
    {
        public UnitsService(IUnitsRepository unitsRepository) : base(unitsRepository)
        {
        }
    }
}