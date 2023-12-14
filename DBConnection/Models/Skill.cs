using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Skill
{
    public int IdSkill { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BackgroundSkill> BackgroundSkills { get; set; } = new List<BackgroundSkill>();

    public virtual ICollection<CharacteristicSkill> CharacteristicSkills { get; set; } = new List<CharacteristicSkill>();

    public virtual ICollection<ClassSkill> ClassSkills { get; set; } = new List<ClassSkill>();
}
