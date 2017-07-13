using HomeBudget.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HomeBudget.Database
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Shopping> ListOfShoping { get; set; }  


        public AppDbContext()
            : base("DefaultConnection")
        {
            System.Data.Entity.Database.SetInitializer(new MySqlInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}