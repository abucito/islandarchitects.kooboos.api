using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Recipe.API.Contexts;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Base
{
    public abstract class BaseCrudRepository<E, T> : IBaseCrudRepository<E, T>
        where E : EntityBase
        where T : class
    {
        private readonly RecipeContext recipeContext;

        private readonly IMapper mapper;

        public BaseCrudRepository(RecipeContext recipeContext, IMapper mapper)
        {
            this.recipeContext = recipeContext ?? throw new ArgumentNullException(nameof(recipeContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IList<T> GetAll()
        {
            return recipeContext.Set<E>().ToList().Select(i => mapper.Map<T>(i)).ToList();
        }

        public T GetById(int id)
        {
            var entity = recipeContext.Find<E>(id);
            if (entity == null)
            {
                return null;
            }

            return mapper.Map<T>(entity);
        }

        public int Insert(T dtoToInsert)
        {
            var entity = mapper.Map<E>(dtoToInsert);
            recipeContext.Add(entity);
            recipeContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(int entityId)
        {
            var entityToRemove = recipeContext.Find<E>(entityId);
            if (entityToRemove != null)
            {
                recipeContext.Remove(entityToRemove);
            }

            recipeContext.SaveChanges();
        }

        public void Update(int entityId, T dtoWithNewValues)
        {
            var entity = recipeContext.Find<T>(entityId);
            if (entity != null)
            {
                mapper.Map(dtoWithNewValues, entity);
            }
            recipeContext.SaveChanges();
        }
    }
}