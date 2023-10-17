using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetAllProjectsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects;

            // "include" command can bring related objects together with the project itself
            var projectsViewModel = await projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Select(x => new ProjectViewModel(x.Id, x.Title, x.Description, x.Client.FullName, x.Freelancer.FullName)).ToListAsync();

            return projectsViewModel;
        }
    }
}
