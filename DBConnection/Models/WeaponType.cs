using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class WeaponType
{
    public int IdweaponType { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Weapon> WeaponIdweapons { get; set; } = new List<Weapon>();
}
