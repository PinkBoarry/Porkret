using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Instrument
{
    public int IdInstrument { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Background> BackgroundIdBackgrounds { get; set; } = new List<Background>();

    public virtual ICollection<Class> ClassIdClasses { get; set; } = new List<Class>();
}
