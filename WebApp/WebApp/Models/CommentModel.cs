using WebApp.Entities;

namespace WebApp.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public int? DocumentId { get; set; }

        public string? Text { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int? AuthorId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public CommentModel(Comment comment)
        {
            Id = comment.Id;
            DocumentId = comment.DocumentId;
            Text = comment.Text;
            DateCreated = comment.DateCreated;
            DateUpdated = comment.DateUpdated;
            AuthorId = comment.AuthorId;
            Name = $"{comment.Author.LastName} {comment.Author.FirstName}";
            Position = comment.Author.Position.PostName;
        }
    }
}
