using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class TimeSpell
{
    public int IdTimeSpell { get; set; }

    public string Time { get; set; } = null!;

    public virtual ICollection<Focus> FocusIdFoci { get; set; } = new List<Focus>();

    public virtual ICollection<Spell> IdSpells { get; set; } = new List<Spell>();
}
