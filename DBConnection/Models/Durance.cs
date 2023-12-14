using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Durance
{
    public int IdDurance { get; set; }

    public string Durance1 { get; set; } = null!;

    public virtual ICollection<Focus> FocusIdFoci { get; set; } = new List<Focus>();

    public virtual ICollection<Spell> IdSpells { get; set; } = new List<Spell>();
}
