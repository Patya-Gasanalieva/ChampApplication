using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class MaterialType
{
    public int Id { get; set; }

    public string MaterialTypeName { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
