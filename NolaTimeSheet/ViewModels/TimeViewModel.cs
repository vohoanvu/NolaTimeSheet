using System;
using DevExpress.Mvvm.CodeGenerators;
using NolaTimeSheet.Models;

namespace NolaTimeSheet.ViewModels
{
    [GenerateViewModel]
    public partial class TimeViewModel
    {
        public long Id { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public decimal Hours { get; set; }

        public DateTime WorkingDate { get; set; }

        public string Reference { get; set; }

        public bool Closed { get; set; }

        public bool Paid { get; set; }

        public int ProjectId { get; set; }


        public TimeViewModel()
        {
        }

        public TimeViewModel(Time timeEntry)
        {
            Id = timeEntry.Id;
            UserId = timeEntry.UserId;
            Description = timeEntry.Description;
            Hours = timeEntry.Hours;
            Reference = timeEntry.Reference;
            Paid = timeEntry.Paid;
            Closed = timeEntry.Closed;
            WorkingDate = timeEntry.WorkingDate;
            ProjectId = timeEntry.ProjectId;
        }
    }

    [GenerateViewModel]
    public partial class TimeSheetFilterViewModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? ProjectId { get; set; }

        public string? UserId { get; set; }
    }
}
