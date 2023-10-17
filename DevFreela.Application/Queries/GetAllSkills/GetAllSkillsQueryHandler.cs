using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        Task<List<SkillViewModel>> IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>.Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = _dbContext.Skills;

            var skillsViewModel = skills.Select(x => new SkillViewModel(x.Id, x.Description)).ToListAsync();

            return skillsViewModel;
        }
    }
}
