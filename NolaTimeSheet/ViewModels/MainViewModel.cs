using System;
using DevExpress.Mvvm.CodeGenerators;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using NolaTimeSheet.Models;
using NolaTimeSheet.Services;
using System.Linq;

namespace NolaTimeSheet.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel
    {
        private readonly IProjectService _projectService;
        private readonly ITimeSheetService _timeSheetService;
        private readonly IUserService _userService;

        [GenerateProperty] private string _status;
        //[GenerateProperty] private string _userId;

        public MainViewModel()
        {
        }
        public MainViewModel(IProjectService projectService,
            ITimeSheetService timeSheetService,
            IUserService userService)
        {
            _projectService = projectService;
            _timeSheetService = timeSheetService;
            _userService = userService;
            ProjectsVm = new ObservableCollection<ProjectViewModel>();
            AppUsers = new ObservableCollection<UserViewModel>();
            Times = new ObservableCollection<TimeViewModel>();
        }

        public ObservableCollection<ProjectViewModel> ProjectsVm { get; set; }
        public ObservableCollection<UserViewModel> AppUsers { get; set; }
        public ObservableCollection<TimeViewModel> Times { get; set; }

        [GenerateCommand(Name = "FetchUserCommand")]
        public async Task FetchUserData()
        {
            var users = await _userService.GetApplicationUsers();
            foreach (var user in users)
            {
                AppUsers.Add(new UserViewModel(user));
            }
        }

        [GenerateCommand(Name = "FetchProjectCommand")]
        public async Task FetchProjectByUser(string userId)
        {
            ProjectsVm.Clear();
            var projects = await _projectService.GetProjectByUserId(Guid.Parse(userId));
            foreach (var project in projects)
            {
               ProjectsVm.Add(new ProjectViewModel(project));
            }
        }

        [GenerateCommand(Name = "FetchUserTimeSheetCommand")]
        public async Task FetchEditableTimeEntries(string userId)
        {
            try
            {
                Times.Clear();
                var times = await _timeSheetService.GetEditableTimeSheetByUserId(userId);
                foreach (var time in times)
                {
                    Times.Add(new TimeViewModel(time));
                }

                await FetchProjectByUser(userId);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Vu debug../ {e}");
                throw;
            }
        }

        [GenerateCommand(Name = "FetchReportTimeSheetCommand")]
        public async Task FetchReportTimeEntries()
        {
            var times = await _timeSheetService.GetAllTimeEntries();
            Times.Clear();
            foreach (var time in times)
            {
                Times.Add(new TimeViewModel(time));
            }
        }

        [GenerateCommand(Name = "CreateNewEntryCommand")]
        public void CreateNewTimeEntry()
        {
            var createTime = new Time
            {
                Description = "",
                UserId = "", // Set this to the ID of the currently selected user
                Hours = 0,
                WorkingDate = DateTime.Now,
                Reference = "",
                Closed = false,
                Paid = false,
                ProjectId = 0 // Set this to the ID of the default project, if any
            };
            Times.Insert(0, new TimeViewModel(createTime));
        }


        [GenerateCommand(Name="UpdateTimeEntryCommand")]
        public async Task UpdateTimeEntry(TimeViewModel input)
        {
            var updatingTime = new Time
            {
                Id = input.Id,
                UserId = input.UserId,
                Description = input.Description,
                Hours = input.Hours,
                WorkingDate = input.WorkingDate,
                Reference = input.Reference,
                ProjectId = input.ProjectId
            };

            var updatedTime = await _timeSheetService.UpdateTimeEntry(updatingTime);

            var existingTimeEntryView = Times.FirstOrDefault(x => x.Id == updatedTime.Id);
            if (existingTimeEntryView != null)
            {
                Times.Remove(existingTimeEntryView);
            }
            Times.Add(new TimeViewModel(updatedTime));
        }
    }
}
