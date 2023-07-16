using NolaTimeSheet.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NolaTimeSheet.Services
{
    public interface IProjectService
    {
        public Task<ObservableCollection<ProjectViewModel>> GetAllProjects();
    }
}
