using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace ychebka_no_norm.Models;

public partial class District
{
    public string Name { get; set; } = null!;


    public virtual ICollection<Estate> Estates { get; set; } = new List<Estate>();
}
