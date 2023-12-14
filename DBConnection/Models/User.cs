using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
