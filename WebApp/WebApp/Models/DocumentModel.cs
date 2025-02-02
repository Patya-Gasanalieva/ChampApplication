using System.Reflection.Metadata;
using WebApp.Entities;
using Document = WebApp.Entities.Document;

namespace WebApp.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }

        public string Titile { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string Category { get; set; } = null!;

        public string HasComments { get; set; }

        public DocumentModel(Document document)
        {
            Id = document.Id;
            Titile = document.Titile;
            DateCreated= document.DateCreated;
            DateUpdated= document.DateUpdated;
            Category = document.Category;
            HasComments = document.HasComments;
        }
    }
}
