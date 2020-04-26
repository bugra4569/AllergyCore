using AllergyCore.Core.Dto.Abstract;
using AllergyCore.Core.Entity;
using AllergyCore.Entity.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Business.Services.Abstarct
{
    public interface IService<T> where T:class,IEntity,new()
    {
        IResult Add(T entity);
        IResult Update(int id, T entity);
        IResult Remove(int id);
        IDataResult<T> Get(int id);
        IDataResult<List<T>> GetAll();
    }
}
