using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Component
{
    public int IdComponent { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Focus> FocusIdFoci { get; set; } = new List<Focus>();

    public virtual ICollection<Spell> IdSpells { get; set; } = new List<Spell>();
}
