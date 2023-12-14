using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Armor
{
    public int IdArmor { get; set; }

    public string Name { get; set; } = null!;

    public sbyte ArmorClass { get; set; }

    public decimal? Weight { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public int ArmorTypeIdarmorType { get; set; }

    public virtual ArmorType ArmorTypeIdarmorTypeNavigation { get; set; } = null!;

    public virtual ICollection<Class> ClassIdclasses { get; set; } = new List<Class>();
}
