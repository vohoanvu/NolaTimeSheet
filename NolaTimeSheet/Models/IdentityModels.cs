using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NolaTimeSheet.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Organization")]
        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid gUserID { get; set; }

        public double DevityTimeToLive { get; set; }

        public bool IsTNCAccepted { get; set; }

        public DateTime TNCAcceptedOn { get; set; }

        public bool Paid { get; set; } = false;

        public string? DevityLoginUrl { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}