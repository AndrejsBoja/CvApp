using System.Collections.Generic;
using System.Linq;
using CvStorage.Core;

namespace CvStorage.Services
{
    public interface ICvService
    {
        void UpdateCv(Cv cv);
        IQueryable<T> Query<T>() where T : Entity;
        IEnumerable<T> Get<T>() where T : Entity;
        T GetById<T>(int id) where T : Entity;
        void Create<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Delete<T>(int id) where T : Entity;
    }
}
