using AllergyCore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Entity.EntityFramework.Entities
{
    public class Foods : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Ingredients> Ingredients { get; set; }

    }
}
