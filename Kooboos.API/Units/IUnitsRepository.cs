using Kooboos.API.Base;
using Kooboos.API.Units.Entities;
using Kooboos.API.Units.Models;

namespace Kooboos.API.Units
{
    public interface IUnitsRepository : IBaseCrudRepository<Unit, UnitDto>
    {

    }
}