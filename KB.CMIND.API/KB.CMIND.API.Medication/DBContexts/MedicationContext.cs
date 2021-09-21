using KB.AUTH.Middleware.Entities;
using KB.CMIND.API.Medication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Medication.DBContexts
{
    public class MedicationContext : DbContext
    {
        public MedicationContext(DbContextOptions<MedicationContext> options) : base(options)
        {
        }
        public DbSet<MedicationDelivery> MedicationDeliveries { get; set; }
        public DbSet<MedicationType> MedicationTypes { get; set; }
        public DbSet<MedicationItem> MedicationItems { get; set; }
        public DbSet<Client> ClientDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("medication_api");
            //modelBuilder.Entity<Category>().HasData(
            //    new Category
            //    {
            //        Id = 1,
            //        Name = "Electronics",
            //        Description = "Electronic Items",
            //    },
            //    new Category
            //    {
            //        Id = 2,
            //        Name = "Clothes",
            //        Description = "Dresses",
            //    },
            //    new Category
            //    {
            //        Id = 3,
            //        Name = "Grocery",
            //        Description = "Grocery Items",
            //    }
            //);
        }
    }
}
