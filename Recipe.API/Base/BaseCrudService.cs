using System;
using System.Collections.Generic;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Base
{
    public abstract class BaseCrudService<E, T> : IBaseCrudService<E, T>
        where E : EntityBase
        where T : class
    {
        private readonly IBaseCrudRepository<E, T> baseCrudRepository;

        public BaseCrudService(IBaseCrudRepository<E, T> baseCrudRepository)
        {
            this.baseCrudRepository = baseCrudRepository ?? throw new ArgumentNullException(nameof(baseCrudRepository));
        }

        public IList<T> GetAll()
        {
            return baseCrudRepository.GetAll();
        }

        public T GetById(int id)
        {
            return baseCrudRepository.GetById(id);
        }

        public int Insert(T dtoToInsert)
        {
            return baseCrudRepository.Insert(dtoToInsert);
        }

        public void Delete(int entityId)
        {
            baseCrudRepository.Delete(entityId);
        }

        public void FullyUpdate(int entityId, T dtoWithNewValues)
        {
            baseCrudRepository.Update(entityId, dtoWithNewValues);
        }
    }
}