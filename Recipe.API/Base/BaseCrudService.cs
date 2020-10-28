using System;
using System.Collections.Generic;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Base
{
    public abstract class BaseCrudService<TEntity, TDto> : IBaseCrudService<TEntity, TDto>
        where TEntity : class, IEntityBase
        where TDto : class
    {
        private readonly IBaseCrudRepository<TEntity, TDto> baseCrudRepository;

        public BaseCrudService(IBaseCrudRepository<TEntity, TDto> baseCrudRepository)
        {
            this.baseCrudRepository = baseCrudRepository ?? throw new ArgumentNullException(nameof(baseCrudRepository));
        }

        public IList<TDto> GetAll()
        {
            return baseCrudRepository.GetAll();
        }

        public TDto GetById(int id)
        {
            return baseCrudRepository.GetById(id);
        }

        public int Insert(TDto dtoToInsert)
        {
            return baseCrudRepository.Insert(dtoToInsert);
        }

        public void Delete(int entityId)
        {
            baseCrudRepository.Delete(entityId);
        }

        public void FullyUpdate(int entityId, TDto dtoWithNewValues)
        {
            baseCrudRepository.Update(entityId, dtoWithNewValues);
        }
    }
}