using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Core.Entity
{
    public interface IEntity
    {
        byte RowStatus { get; set; }
        string UpdateUser { get; set; }
        DateTime? UpdateDate { get; set; }
        string InsertUser { get; set; }
        DateTime? InsertDate { get; set; }
        string DeleteUser { get; set; }
        DateTime? DeleteDate { get; set; }

    }
}
