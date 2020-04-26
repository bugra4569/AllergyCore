using AllergyCore.Core.Repository.EntityFramework;
using AllergyCore.Entity.EntityFramework.Entities;
using AllergyCore.Entity.EntityFramework.MSSQL.Context;
using AllergyCore.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Repository.Concrete
{
    public class FoodRepository : EfBaseRepository<Foods, AllergyMssqlContext>, IFoodRepository
    {
    }
}
