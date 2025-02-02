using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class CalendarType
{
    public int Id { get; set; }

    public string CalendarTypeName { get; set; } = null!;

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
}
