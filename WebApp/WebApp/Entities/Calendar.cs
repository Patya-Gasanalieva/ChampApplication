using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Calendar
{
    public int Id { get; set; }

    public int CalendarTypeId { get; set; }

    public int? DivisionId { get; set; }

    public int EmployeeId { get; set; }

    public virtual CalendarType CalendarType { get; set; } = null!;

    public virtual Division? Division { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
