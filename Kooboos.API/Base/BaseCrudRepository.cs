using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Kooboos.API.Contexts;
using Kooboos.API.Entities;
using Kooboos.API.Models;

namespace Kooboos.API.Base
{
    public abstract class BaseCrudRepository<TEntity, TDto> : IBaseCrudRepository<TEntity, TDto>
        where TEntity : class, IEntityBase
        where TDto : class
    {
        private readonly RecipeContext recipeContext;

        private readonly IMapper mapper;

        public BaseCrudRepository(RecipeContext recipeContext, IMapper mapper)
        {
            this.recipeContext = recipeContext ?? throw new ArgumentNullException(nameof(recipeContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IList<TDto> GetAll()
        {
            return recipeContext.Set<TEntity>().ToList().Select(i => mapper.Map<TDto>(i)).ToList();
        }

        public TDto GetById(int id)
        {
            var entity = recipeContext.Find<TEntity>(id);
            if (entity == null)
            {
                return null;
            }

            return mapper.Map<TDto>(entity);
        }

        public int Insert(TDto dtoToInsert)
        {
            var entity = mapper.Map<TEntity>(dtoToInsert);
            recipeContext.Add(entity);
            recipeContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(int entityId)
        {
            var entityToRemove = recipeContext.Find<TEntity>(entityId);
            if (entityToRemove != null)
            {
                recipeContext.Remove(entityToRemove);
            }

            recipeContext.SaveChanges();
        }

        public void Update(int entityId, TDto dtoWithNewValues)
        {
            var entity = recipeContext.Find<TEntity>(entityId);
            if (entity != null)
            {
                mapper.Map(dtoWithNewValues, entity);
            }
            recipeContext.SaveChanges();
        }
    }
}