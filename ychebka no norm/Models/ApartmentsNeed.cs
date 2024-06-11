using System;
using System.Collections.Generic;

namespace ychebka_no_norm.Models;

public partial class ApartmentsNeed
{
    public int Id { get; set; }

    public int? MinSquare { get; set; }

    public int? MaxSquare { get; set; }

    public int? MinRoomsCount { get; set; }

    public int? MaxRoomsCount { get; set; }

    public int? MinFloor { get; set; }

    public int? MaxFloor { get; set; }
}
