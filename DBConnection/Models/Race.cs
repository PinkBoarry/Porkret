using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Race
{
    public int Idrace { get; set; }

    public string Name { get; set; } = null!;

    public string History { get; set; } = null!;

    public sbyte Speed { get; set; }

    public string Peculiarities { get; set; } = null!;

    public string IconPath { get ; set; } = null!;

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual ICollection<Language> LanguageIdLanguages { get; set; } = new List<Language>();
}
