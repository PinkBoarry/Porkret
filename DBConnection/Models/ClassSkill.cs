using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class ClassSkill
{
    public int ClassIdClass { get; set; }

    public int SkillIdSkill { get; set; }

    public sbyte? Bonus { get; set; }

    public virtual Class ClassIdClassNavigation { get; set; } = null!;

    public virtual Skill SkillIdSkillNavigation { get; set; } = null!;
}
