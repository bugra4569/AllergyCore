using AllergyCore.Core.Dto.Abstract;
using AllergyCore.Entity.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Business.Services.Abstarct
{
    public interface IFoodService : IService<Foods>
    {
        IDataResult<List<Foods>> GetListByAllergyId(int allergyId);
        IDataResult<List<Foods>> GetListByMaterialId(int materialId);

    }
}
