using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NolaTimeSheet.Models;

namespace NolaTimeSheet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<AspNetUserProject> AspNetUserProjects { get; set; }

        public DbSet<Time> Times { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // additional model configurations...

            builder.Entity<AspNetUserProject>()
                .HasKey(up => new { up.UserId, up.ProjectId });
        }
    }
}
