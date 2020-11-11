using Kooboos.API.Base;
using Kooboos.API.Units.Entities;
using Kooboos.API.Units.Models;

namespace Kooboos.API.Units
{
    public class UnitsService : BaseCrudService<Unit, UnitDto>, IUnitsService
    {
        public UnitsService(IUnitsRepository unitsRepository) : base(unitsRepository)
        {
        }
    }
}