using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class TrainingClass
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public string? Description { get; set; }

    public int? MaterialId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Material? Material { get; set; }
}
