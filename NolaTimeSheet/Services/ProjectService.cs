
using Microsoft.EntityFrameworkCore;
using NolaTimeSheet.Data;
using NolaTimeSheet.Models;
using NolaTimeSheet.ViewModels;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NolaTimeSheet.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ObservableCollection<ProjectViewModel>> GetAllProjects()
        {
            var result = new ObservableCollection<ProjectViewModel>();
            var projects = await _context.Projects.ToListAsync();

            foreach (var project in projects)
            {
                result.Add(new ProjectViewModel(project));
            }

            return result;
        }

        public async Task<List<Project>> GetProjectByUserId(Guid userId)
        {
            var projects = await _context.AspNetUserProjects
                .Where(up => up.UserId == userId.ToString() && !up.Project.Closed)
                .Select(up => up.Project).ToListAsync();

            return projects;
        }
    }
}
