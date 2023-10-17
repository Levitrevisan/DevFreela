using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public ProjectDetailsViewModel? GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            if (project == null) return null;
            var projectViewModel = new ProjectDetailsViewModel(project.Id, project.Title, project.Description, project.TotalCost);

            return projectViewModel;
        }

    }
}
