using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Weakness
{
    public int IdWeakness { get; set; }

    public string Description { get; set; } = null!;

    public int BackgroundIdBackground { get; set; }

    public virtual Background BackgroundIdBackgroundNavigation { get; set; } = null!;
}
