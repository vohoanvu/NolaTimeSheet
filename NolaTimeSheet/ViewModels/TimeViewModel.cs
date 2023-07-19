using System;
using System.ComponentModel;
using DevExpress.Mvvm.CodeGenerators;
using NolaTimeSheet.Models;

namespace NolaTimeSheet.ViewModels
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        private long _id;
        private string _userId;
        private int _projectId;
        private string _description;
        private decimal _hours;
        private DateTime _workingDate;
        private string _reference;

        public event PropertyChangedEventHandler PropertyChanged;

        public long Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string UserId
        {
            get => _userId;
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }

        public int ProjectId
        {
            get => _projectId;
            set
            {
                if (_projectId != value)
                {
                    _projectId = value;
                    OnPropertyChanged(nameof(ProjectId));
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public decimal Hours
        {
            get => _hours;
            set
            {
                if (_hours != value)
                {
                    _hours = value;
                    OnPropertyChanged(nameof(Hours));
                }
            }
        }

        public DateTime WorkingDate
        {
            get => _workingDate;
            set
            {
                if (_workingDate != value)
                {
                    _workingDate = value;
                    OnPropertyChanged(nameof(WorkingDate));
                }
            }
        }

        public string Reference
        {
            get => _reference;
            set
            {
                if (_reference != value)
                {
                    _reference = value;
                    OnPropertyChanged(nameof(Reference));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


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
