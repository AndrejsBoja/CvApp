using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CvStorage.Core;
using CvStorage.Core.Services;
using CvStorage.Data;

namespace CvStorage.Services
{
    public class EntityDbService : IEntityDbService
    {
        protected readonly CvStorageDbContext EntityContext; 
        public EntityDbService(CvStorageDbContext context)
        {
            EntityContext = context;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return EntityContext.Set<T>();
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
           return  EntityContext.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return EntityContext.Set<T>().SingleOrDefault(entity => entity.Id == id);
        }

        public void Create<T>(T entity) where T : Entity
        {
            EntityContext.Set<T>().Add(entity);
            EntityContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            
            EntityContext.Entry(entity).State = EntityState.Modified;
            EntityContext.SaveChanges();
        }

        public void Delete<T>(int id) where T : Entity
        {
            var cv = GetById<Cv>(id);
            if (cv == null) return;
            EntityContext.Set<Cv>().Remove(cv);
            EntityContext.SaveChanges();   
        }
    }
}