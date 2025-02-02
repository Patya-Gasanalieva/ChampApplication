using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Absence
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly StartDate { get; set; }

    public int ReplacementId { get; set; }

    public string Reason { get; set; } = null!;

    public DateOnly EndDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Employee Replacement { get; set; } = null!;
}
