using AllergyCore.Entity.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Entity.EntityFramework.MSSQL.Context
{
    public class AllergyMssqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database= AllergyDb; Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
            
        }      

        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Foods> Foods{ get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Materials> Materials { get; set; }
    }
}
