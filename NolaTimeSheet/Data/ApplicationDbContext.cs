using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using NolaTimeSheet.Models;

namespace NolaTimeSheet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<AspNetUserProject> AspNetUserProjects { get; set; }

        public DbSet<Time> Times { get; set; }

        public DbSet<ApplicationUser> AspNetUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // additional model configurations...

            builder.Entity<AspNetUserProject>()
                .HasKey(up => new { up.UserId, up.ProjectId });

            builder.Entity<ApplicationUser>(b =>
            {
                b.HasKey(u => u.Id); // Set key
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.HasKey(l => l.UserId); // Set key
            });

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.HasKey(r => new { r.UserId, r.RoleId }); // Set key
            });
        }
    }
}
