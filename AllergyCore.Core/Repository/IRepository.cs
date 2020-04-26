using AllergyCore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AllergyCore.Core.Repository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        int Add(T Entity);
        void Update(T Entity);
        void Remove(T Entity);
    }
}
