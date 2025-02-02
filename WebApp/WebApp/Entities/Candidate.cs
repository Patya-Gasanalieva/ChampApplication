using System;
using System.Collections.Generic;

namespace WebApp.Entities;

public partial class Candidate
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string Resume { get; set; } = null!;

    public DateOnly ApplicationDate { get; set; }

    public string Area { get; set; } = null!;
}
