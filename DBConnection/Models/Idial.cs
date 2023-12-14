using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Idial
{
    public int IdIdial { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int BackgroundIdBackground { get; set; }

    public virtual Background BackgroundIdBackgroundNavigation { get; set; } = null!;
}
