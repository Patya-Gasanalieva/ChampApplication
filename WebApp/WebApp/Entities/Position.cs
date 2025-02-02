using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Position
{
    public int Id { get; set; }

    public string PostName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
