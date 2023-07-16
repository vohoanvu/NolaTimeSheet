using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

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
    }
}