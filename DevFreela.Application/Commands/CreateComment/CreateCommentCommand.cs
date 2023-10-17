using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

    }
}
