using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Entity.EntityFramework.Entities
{
    public class Units : BaseEntity
    {
        public int Id{ get; set; }
        public string Description { get; set; }
    }
}
