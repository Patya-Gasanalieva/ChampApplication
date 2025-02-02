using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class EventStatus
{
    public int Id { get; set; }

    public string EventStatusName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
