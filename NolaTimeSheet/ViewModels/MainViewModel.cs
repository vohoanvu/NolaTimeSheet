using System;
using DevExpress.Mvvm.CodeGenerators;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NolaTimeSheet.Models;
using NolaTimeSheet.Services;
using System.Linq;
using System.Reflection;

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
            var projects = await _projectService.GetProjectByUserId(Guid.Parse(userId));
            foreach (var project in projects)
            {
               ProjectsVm.Add(new ProjectViewModel(project));
            }
        }

        [GenerateCommand(Name = "FetchUserTimeSheetCommand")]
        public async Task FetchEditableTimeEntries(string userId)
        {
            Times.Clear();
            var times = await _timeSheetService.GetTimeEntriesByUserId(userId);
            foreach (var time in times)
            {
                Times.Add(new TimeViewModel(time));
            }

            await FetchProjectByUser(userId);
        }

        [GenerateCommand]
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
        public void CreateNewTimeEntry(TimeViewModel createTime)
        {
            var postTimeRequest = new Time()
            {
                Id = createTime.Id,
                Description = createTime.Description,
                UserId = createTime.UserId,
                Hours = createTime.Hours,
                WorkingDate = createTime.WorkingDate,
                Reference = createTime.Reference,
                Closed = createTime.Closed,
                Paid = createTime.Paid,
                ProjectId = createTime.ProjectId
            };
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
                Closed = input.Closed,
                Paid = input.Paid,
                ProjectId = input.ProjectId
            };

            var updatedTime = await _timeSheetService.UpdateTimeEntry(updatingTime);

            //fetching updated rows back to Times observablecollection.
            Times = new ObservableCollection<TimeViewModel>(Times.Where(x => x.Id != updatedTime.Id))
            {
                new TimeViewModel(updatedTime)
            };
        }
    }
}
