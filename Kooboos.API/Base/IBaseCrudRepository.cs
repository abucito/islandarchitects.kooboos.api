using System.Collections.Generic;

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