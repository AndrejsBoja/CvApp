﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using CvStorage.Core;
using CvStorage.Core.Services;
using CvStorage.Data;

namespace CvStorage.Services
{
    public class EntityDbService : IEntityDbService
    {
        private readonly CvStorageDbContext _entityContext; 
        public EntityDbService(CvStorageDbContext context)
        {
            _entityContext = context;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _entityContext.Set<T>();
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
           return  _entityContext.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _entityContext.Set<T>().SingleOrDefault(entity => entity.Id == id);
        }

        public void Create<T>(T entity) where T : Entity
        {
            _entityContext.Set<T>().Add(entity);
            _entityContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity // vai pareizi ?
        {
            //_entityContext.Set<T>().AddOrUpdate(entity);
            //_entityContext.Set<T>().Attach(entity);
            //_entityContext.SaveChanges();
           
            _entityContext.Entry(entity).State = EntityState.Modified;
            _entityContext.SaveChanges();
        }

        public void Delete<T>(int id) where T : Entity
        {
            var cv = GetById<T>(id);
            if (cv == null) return;
            _entityContext.Set<T>().Remove(cv);
            _entityContext.SaveChanges();
        }
    }
}