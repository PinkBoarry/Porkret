using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Characteristic
{
    public int IdCharacteristic { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CharacteristicCharacter> CharacteristicCharacters { get; set; } = new List<CharacteristicCharacter>();

    public virtual ICollection<CharacteristicSkill> CharacteristicSkills { get; set; } = new List<CharacteristicSkill>();
}
