using System;
using System.Collections.Generic;

namespace ychebka_no_norm.Models;

public partial class Deal
{
    public int? Id { get; set; }

    public int Suggestion { get; set; }

    public int Need { get; set; }

    public virtual Need NeedNavigation { get; set; } = null!;

    public virtual Suggestion SuggestionNavigation { get; set; } = null!;
}
