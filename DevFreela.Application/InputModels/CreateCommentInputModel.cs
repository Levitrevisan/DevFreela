namespace DevFreela.Application.InputModels
{
    public class CreateCommentInputModel
    {
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}