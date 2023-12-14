using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class BackgroundSkill
{
    public int BackgroundIdBackground { get; set; }

    public int SkillIdskill { get; set; }

    public sbyte Bonus { get; set; }

    public virtual Background BackgroundIdBackgroundNavigation { get; set; } = null!;

    public virtual Skill SkillIdskillNavigation { get; set; } = null!;
}
