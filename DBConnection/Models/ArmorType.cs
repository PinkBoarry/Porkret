using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class ArmorType
{
    public int IdArmorType { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Armor> Armors { get; set; } = new List<Armor>();
}
