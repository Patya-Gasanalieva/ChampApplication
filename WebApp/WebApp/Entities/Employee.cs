using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public DateOnly? BirthDay { get; set; }

    public int? DivisionId { get; set; }

    public int? PositionId { get; set; }

    public string? WorkPhone { get; set; }

    public string Cabinet { get; set; } = null!;

    public string? Email { get; set; }

    public string? MobilePhone { get; set; }

    public int? DirectorId { get; set; }

    public int? AssistantId { get; set; }

    public string? OtherInfo { get; set; }

    public virtual ICollection<Absence> AbsenceEmployees { get; set; } = new List<Absence>();

    public virtual ICollection<Absence> AbsenceReplacements { get; set; } = new List<Absence>();

    public virtual Employee? Assistant { get; set; }

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Employee? Director { get; set; }

    public virtual Division? Division { get; set; }

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    public virtual ICollection<Employee> InverseAssistant { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> InverseDirector { get; set; } = new List<Employee>();

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual Position? Position { get; set; }
}
