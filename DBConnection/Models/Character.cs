using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Character
{
    public int IdCharacter { get; set; }

    public string Name { get; set; } = null!;

    public sbyte Hitcount { get; set; }

    public string? TextBackground { get; set; }

    public string? Allies { get; set; }

    public string? Otherinformation { get; set; }

    public int? UserIduser { get; set; }

    public int IdeologyIdIdeology { get; set; }

    public int BackgroundIdBackground { get; set; }

    public int ClassIdClass { get; set; }

    public int RaceIdRace { get; set; }

    public virtual Background BackgroundIdBackgroundNavigation { get; set; } = null!;

    public virtual ICollection<CharacteristicCharacter> CharacteristicCharacters { get; set; } = new List<CharacteristicCharacter>();

    public virtual Class ClassIdClassNavigation { get; set; } = null!;

    public virtual Ideology IdeologyIdIdeologyNavigation { get; set; } = null!;

    public virtual Race RaceIdRaceNavigation { get; set; } = null!;

    public virtual User? UserIduserNavigation { get; set; }
}
