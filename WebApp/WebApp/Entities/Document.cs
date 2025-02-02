using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Document
{
    public int Id { get; set; }

    public string Titile { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public string Category { get; set; } = null!;

    public  string? HasComments { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
