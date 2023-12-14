using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Focus
{
    public int IdFocus { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Class> ClassIdclasses { get; set; } = new List<Class>();

    public virtual ICollection<Component> ComponentIdComponents { get; set; } = new List<Component>();

    public virtual ICollection<Distance> DistanceIdDistances { get; set; } = new List<Distance>();

    public virtual ICollection<Durance> DuranceIdDurances { get; set; } = new List<Durance>();

    public virtual ICollection<TimeSpell> TimeSpellIdTimeSpells { get; set; } = new List<TimeSpell>();
}
