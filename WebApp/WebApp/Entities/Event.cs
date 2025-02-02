using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Event
{
    public int Id { get; set; }

    public string EventName { get; set; } = null!;

    public int EventStatusId { get; set; }

    public int EventTypeId { get; set; }

    public DateOnly StrartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string ResponsiblePerson { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual EventStatus EventStatus { get; set; } = null!;

    public virtual EventType EventType { get; set; } = null!;

    public virtual ICollection<TrainingClass> TrainingClasses { get; set; } = new List<TrainingClass>();
}
