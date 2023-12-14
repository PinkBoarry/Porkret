using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Item
{
    public int IdItem { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public decimal? Weight { get; set; }

    public virtual ICollection<Kit> KitIdkits { get; set; } = new List<Kit>();
}
