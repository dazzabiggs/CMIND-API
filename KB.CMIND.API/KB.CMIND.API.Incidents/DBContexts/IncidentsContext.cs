using KB.AUTH.Middleware.Entities;
using KB.CMIND.API.Incidents.Entities;
using Microsoft.EntityFrameworkCore;

namespace KB.CMIND.API.Incidents.DBContexts
{
    public class IncidentsContext : DbContext
    {
        public IncidentsContext(DbContextOptions<IncidentsContext> options) : base(options)
        {
        }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentType> IncidentTypes { get; set; }
        public DbSet<Client> ClientDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("incidents_api");
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
