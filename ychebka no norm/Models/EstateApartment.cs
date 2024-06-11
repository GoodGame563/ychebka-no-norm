using System;
using System.Collections.Generic;

namespace ychebka_no_norm.Models;

public partial class EstateApartment
{
    public int Id { get; set; }

    public int? Floor { get; set; }

    public int? RoomsCount { get; set; }

    public double? Square { get; set; }
}
