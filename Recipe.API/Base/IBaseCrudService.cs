using System.Collections.Generic;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Base
{
    public interface IBaseCrudService<E, T>
        where E : class, IEntityBase
        where T : class
    {
        IList<T> GetAll();

        T GetById(int id);

        int Insert(T dtoToInsert);

        void Delete(int entityId);

        void FullyUpdate(int entityId, T dtoWithNewValues);
    }
}