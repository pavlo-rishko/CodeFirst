using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository(DbContext context)
        {            
            Entities = context.Set<TEntity>();
        }

        private DbSet<TEntity> Entities { get; }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }
        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }
        public void Insert(TEntity obj)
        {
            Entities.Add(obj);
        }
        public void Update(TEntity obj)
        {
            Entities.Update(obj);
        }
        public void DeleteById(object id)
        {
            TEntity existing = Entities.Find(id);
            Entities.Remove(existing);
        }
        public int Count()
        {
            return Entities.Count<TEntity>();
        }
    }
}

