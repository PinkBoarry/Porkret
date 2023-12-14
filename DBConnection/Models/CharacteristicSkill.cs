using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class CharacteristicSkill
{
    public int CharacteristicIdcharacteristic { get; set; }

    public int SkillIdSkill { get; set; }

    public sbyte Bonus { get; set; }

    public virtual Characteristic CharacteristicIdcharacteristicNavigation { get; set; } = null!;

    public virtual Skill SkillIdSkillNavigation { get; set; } = null!;
}
