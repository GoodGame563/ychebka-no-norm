using System;
using System.Collections.Generic;

namespace ychebka_no_norm.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? FirstName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Need> Needs { get; set; } = new List<Need>();

    public virtual ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
}
