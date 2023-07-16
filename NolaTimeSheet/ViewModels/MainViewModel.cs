using DevExpress.Mvvm.CodeGenerators;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NolaTimeSheet.Data;
using NolaTimeSheet.Services;

namespace NolaTimeSheet.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel
    {
        private readonly IProjectService _projectService;

        [GenerateProperty] private string _Status;
        [GenerateProperty] private string _UserName;

        [GenerateCommand]
        private void Login() => Status = "User: " + UserName;

        private bool CanLogin() => !string.IsNullOrEmpty(UserName);

        public MainViewModel()
        {
        }
        public MainViewModel(IProjectService projectService)
        {
            _projectService = projectService;
            ProjectsVm = new ObservableCollection<ProjectViewModel>();
        }

        public ObservableCollection<ProjectViewModel> ProjectsVm { get; set; }


        [GenerateCommand(Name = "FetchProjectCommand")]
        public async Task FetchProjectData()
        {
            var projects = await _projectService.GetAllProjects();
            foreach (var project in projects)
            {
               ProjectsVm.Add(project);
            }
        }
    }
}
