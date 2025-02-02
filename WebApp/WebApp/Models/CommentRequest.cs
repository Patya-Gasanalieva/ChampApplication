namespace WebApp.Models
{
    public class CommentRequest
    {
        public int DocumentId { get; set; }

        public string? Text { get; set; }

        public int AuthorId { get; set; }
    }
}
