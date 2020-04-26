using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Entity.EntityFramework.Entities
{
    public class Materials : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Ingredients> Ingredients { get; set; }
        public ICollection<Allergies> Allergies { get; set; }


    }
}
