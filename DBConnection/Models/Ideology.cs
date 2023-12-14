using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Ideology
{
    public int IdIdeology { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
