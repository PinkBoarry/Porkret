using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Weapon
{
    public int IdWeapon { get; set; }

    public string Name { get; set; } = null!;

    public string? Damage { get; set; }

    public decimal Price { get; set; }

    public decimal? Weight { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Class> ClassIdClasses { get; set; } = new List<Class>();

    public virtual ICollection<WeaponType> WeaponTypeIdweaponTypes { get; set; } = new List<WeaponType>();
}
