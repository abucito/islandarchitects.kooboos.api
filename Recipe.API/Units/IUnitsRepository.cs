using Recipe.API.Base;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Units
{
    public interface IUnitsRepository : IBaseCrudRepository<Unit, UnitDto>
    {

    }
}