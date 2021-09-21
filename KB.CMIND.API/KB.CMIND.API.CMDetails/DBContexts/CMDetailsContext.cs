using KB.AUTH.Middleware.Entities;
using KB.CMIND.API.CMDetails.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.DBContexts
{
    public class CMDetailsContext : DbContext
    {
        public CMDetailsContext(DbContextOptions<CMDetailsContext> options) : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ChildMinder> ChildMinders { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Client> ClientDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("details_api");
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
