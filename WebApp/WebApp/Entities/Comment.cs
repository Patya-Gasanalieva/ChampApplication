using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public int AuthorId { get; set; }

    public virtual Employee Author { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;
}
