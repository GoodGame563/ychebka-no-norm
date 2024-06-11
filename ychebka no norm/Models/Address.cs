using System;
using System.Collections.Generic;

namespace ychebka_no_norm.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? House { get; set; }

    public string? Number { get; set; }

    public virtual ICollection<Estate> Estates { get; set; } = new List<Estate>();

    public virtual ICollection<Need> Needs { get; set; } = new List<Need>();
}
