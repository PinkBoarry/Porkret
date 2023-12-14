using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class CharacteristicCharacter
{
    public int CharacteristicIdCharacteristic { get; set; }

    public int CharacterIdCharacter { get; set; }

    public sbyte? Value { get; set; }

    public virtual Character CharacterIdCharacterNavigation { get; set; } = null!;

    public virtual Characteristic CharacteristicIdCharacteristicNavigation { get; set; } = null!;
}
