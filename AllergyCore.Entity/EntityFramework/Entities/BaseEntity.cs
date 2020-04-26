using AllergyCore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Entity.EntityFramework.Entities
{
    public class BaseEntity : IEntity
    {
        public DateTime? InsertDate { get; set; }
        public string InsertUser { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string UpdateUser { get; set; }
        public byte RowStatus { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
