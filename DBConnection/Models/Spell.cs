using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Spell
{
    public int Idspell { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Class> ClassIdclasses { get; set; } = new List<Class>();

    public virtual ICollection<Component> IdComponents { get; set; } = new List<Component>();

    public virtual ICollection<Distance> IdDistances { get; set; } = new List<Distance>();

    public virtual ICollection<Durance> IdDurances { get; set; } = new List<Durance>();

    public virtual ICollection<TimeSpell> IdTimeSpells { get; set; } = new List<TimeSpell>();
}
