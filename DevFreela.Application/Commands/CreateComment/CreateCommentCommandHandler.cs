using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public CreateCommentCommandHandler(DevFreelaDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.CommentText, request.ProjectId, request.UserId);

            await _dbContext.ProjectComments.AddAsync(comment);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
