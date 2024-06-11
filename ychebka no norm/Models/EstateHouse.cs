using System;
using System.Collections.Generic;

namespace ychebka_no_norm.Models;

public partial class EstateHouse
{
    public int Id { get; set; }

    public int? FloorsCount { get; set; }

    public int? RoomsCount { get; set; }

    public double? Square { get; set; }
}
