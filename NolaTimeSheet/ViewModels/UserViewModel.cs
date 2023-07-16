using DevExpress.Mvvm.CodeGenerators;
using NolaTimeSheet.Models;
using System;

namespace NolaTimeSheet.ViewModels
{
    [GenerateViewModel]
    public partial class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int? OrganizationId { get; set; }

        public double DevityTimeToLive { get; set; }

        public bool IsTNCAccepted { get; set; }

        public DateTime TNCAcceptedOn { get; set; }

        public bool Paid { get; set; } = false;

        public string? DevityLoginUrl { get; set; }

        public UserViewModel(ApplicationUser appUser)
        {
            Id = appUser.Id;
            OrganizationId = appUser.OrganizationId;
            DevityTimeToLive = appUser.DevityTimeToLive;
            IsTNCAccepted = appUser.IsTNCAccepted;
            TNCAcceptedOn = appUser.TNCAcceptedOn;
            Paid = appUser.Paid;
            DevityLoginUrl = appUser.DevityLoginUrl;
            UserName = appUser.UserName;
            Email = appUser.Email;
        }
    }
}
