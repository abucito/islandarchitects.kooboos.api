using System.Collections.Generic;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Base
{
    public interface IBaseCrudService<E, T>
        where E : EntityBase
        where T : class
    {
        IList<T> GetAll();

        T GetById(int id);

        int InsertIngredient(T dtoToInsert);

        void DeleteIngredient(int entityId);

        void FullyUpdateIngredient(int entityId, T dtoWithNewValues);
    }
}