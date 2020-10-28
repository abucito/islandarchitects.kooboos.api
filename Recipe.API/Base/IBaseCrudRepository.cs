using System.Collections.Generic;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Base
{
    public interface IBaseCrudRepository<TEntity, TDto>
        where TEntity : class, IEntityBase
        where TDto : class
    {
        IList<TDto> GetAll();

        TDto GetById(int id);

        int Insert(TDto dtoToInsert);

        void Delete(int entityId);

        void Update(int entityId, TDto dtoWithNewValues);
    }
}