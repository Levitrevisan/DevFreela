using DevFreela.Core.Exceptions;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProject
{
    internal class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public DeleteProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {

            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            if (project != null)
            {
                project.Cancel();
                await _dbContext.SaveChangesAsync();
            }

            else
            {
                throw new ProjectNotFound();
            }

            return Unit.Value;
        }
    }
}
