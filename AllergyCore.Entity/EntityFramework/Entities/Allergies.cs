using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Entity.EntityFramework.Entities
{
    public class Allergies : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptons { get; set; }
        public string Treatment { get; set; }
        public int MaterialId { get; set; }
        public Materials Material { get; set; }
        public bool IsDeathlyForKids { get; set; }
        public bool IsCommon { get; set; }
        public decimal RateOfIncidence { get; set; }
        public bool IsCritical { get; set; }



    }
}
