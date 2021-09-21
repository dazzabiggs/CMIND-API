using KB.AUTH.Middleware.Entities;
using KB.CMIND.API.ParentChild.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.ParentChild.DBContexts
{
    public class ParentChildContext : DbContext
    {
        public ParentChildContext(DbContextOptions<ParentChildContext> options) : base(options)
        {
        }
        public DbSet<Child> Children { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> ClientDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("child_record_api");
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
