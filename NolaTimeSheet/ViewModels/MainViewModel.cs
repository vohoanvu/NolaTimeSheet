using System;
using DevExpress.Mvvm.CodeGenerators;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NolaTimeSheet.Data;
using NolaTimeSheet.Services;
using DevExpress.Mvvm.Native;
using DevExpress.Pdf.Native.BouncyCastle.Utilities;

namespace NolaTimeSheet.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel
    {
        private readonly IProjectService _projectService;
        private readonly ITimeSheetService _timeSheetService;
        private readonly IUserService _userService;

        [GenerateProperty] private string _status;
        [GenerateProperty] private string _userId;

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
        public async Task FetchProjectData()
        {
            var projects = await _projectService.GetAllProjects();
            foreach (var project in projects)
            {
               ProjectsVm.Add(project);
            }
        }

        [GenerateCommand(Name = "FetchUserTimeSheetCommand")]
        public async Task FetchEditableTimeEntries(string userId)
        {
            throw new NotImplementedException();
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
    }
}
