using System;
using System.Collections.Generic;

namespace ychebka_no_norm.Models;

public partial class Suggestion
{
    public int Id { get; set; }

    public int Client { get; set; }

    public int Realtor { get; set; }

    public int Estate { get; set; }

    public decimal Price { get; set; }

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual Estate EstateNavigation { get; set; } = null!;

    public virtual Realtor RealtorNavigation { get; set; } = null!;
}
