using AllergyCore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AllergyCore.Core.Repository.EntityFramework
{
    public class EfBaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public int Add(TEntity Entity)
        {
            using (TContext context = new TContext())
            {
                Entity.RowStatus = 0;
                Entity.InsertDate = DateTime.Now;
                Entity.InsertUser = "DefaultUser";
                var AddedEntity = context.Entry(Entity);
                AddedEntity.State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().Where(x => x.RowStatus == 0).SingleOrDefault(filter);
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null ? context.Set<TEntity>().Where(x => x.RowStatus == 0).ToList() : context.Set<TEntity>().Where(x => x.RowStatus == 0).Where(filter).ToList();
        }

        public void Remove(TEntity Entity)
        {
            using (var context = new TContext())
            {
                Entity.RowStatus = 1;
                Entity.DeleteDate = DateTime.Now;
                Entity.DeleteUser = "DefaultUser";
                var DeletedEntity = context.Entry(Entity);
                DeletedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Update(TEntity Entity)
        {
            using (var context = new TContext())
            {
                Entity.UpdateDate = DateTime.Now;
                Entity.UpdateUser = "DefaultUser";
                var UpdatedEntity = context.Entry(Entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
