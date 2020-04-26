using AllergyCore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Entity.EntityFramework.Entities
{
    public class Ingredients : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int MaterialId { get; set; }
        public decimal Amount { get; set; }
        public int UnitId { get; set; }
        public Units Units { get; set; }
        public Foods Food { get; set; }
        public Materials Material { get; set; }


    }
}
