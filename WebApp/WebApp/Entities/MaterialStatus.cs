using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class MaterialStatus
{
    public int Id { get; set; }

    public string MaterialStatusName { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
