using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Division
{
    public int Id { get; set; }

    public string DivisionName { get; set; } = null!;

    public string? Description { get; set; }

    public int? DirectorId { get; set; }

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual Employee? Director { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
