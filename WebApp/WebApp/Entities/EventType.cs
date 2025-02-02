using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class EventType
{
    public int Id { get; set; }

    public string EventTypeName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
