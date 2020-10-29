using System.Collections.Generic;
using Kooboos.API.Entities;
using Kooboos.API.Models;

namespace Kooboos.API.Base
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