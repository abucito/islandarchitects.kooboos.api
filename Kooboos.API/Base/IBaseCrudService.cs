using System.Collections.Generic;

namespace Kooboos.API.Base
{
    public interface IBaseCrudService<TEntity, TDto>
        where TEntity : class, IEntityBase
        where TDto : class
    {
        IList<TDto> GetAll();

        TDto GetById(int id);

        int Insert(TDto dtoToInsert);

        void Delete(int entityId);

        void FullyUpdate(int entityId, TDto dtoWithNewValues);
    }
}