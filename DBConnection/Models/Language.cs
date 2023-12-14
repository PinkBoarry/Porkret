using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Language
{
    public int Idlanguage { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Race> RaceIdRaces { get; set; } = new List<Race>();
}
