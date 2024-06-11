using System;
using System.Collections.Generic;

namespace ychebka_no_norm.Models;

public partial class Realtor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Comission { get; set; }

    public virtual ICollection<Need> Needs { get; set; } = new List<Need>();

    public virtual ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
}
