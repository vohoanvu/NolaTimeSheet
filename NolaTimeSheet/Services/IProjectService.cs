using NolaTimeSheet.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NolaTimeSheet.Models;

namespace NolaTimeSheet.Services
{
    public interface IProjectService
    {
        public Task<ObservableCollection<ProjectViewModel>> GetAllProjects();

        public Task<List<Project>> GetProjectByUserId(Guid userId);
    }
}
