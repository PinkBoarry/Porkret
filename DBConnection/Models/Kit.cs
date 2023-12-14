using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Kit
{
    public int Idkit { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Background> BackgroundIdbackgrounds { get; set; } = new List<Background>();

    public virtual ICollection<Item> ItemIditems { get; set; } = new List<Item>();
}
