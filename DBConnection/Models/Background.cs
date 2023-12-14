using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Background
{
    public int IdBackground { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<BackgroundSkill> BackgroundSkills { get; set; } = new List<BackgroundSkill>();

    public virtual ICollection<CharacterTrait> CharacterTraits { get; set; } = new List<CharacterTrait>();

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual ICollection<Devotion> Devotions { get; set; } = new List<Devotion>();

    public virtual ICollection<Idial> Idials { get; set; } = new List<Idial>();

    public virtual ICollection<Weakness> Weaknesses { get; set; } = new List<Weakness>();

    public virtual ICollection<Instrument> InstrumentIdInstruments { get; set; } = new List<Instrument>();

    public virtual ICollection<Kit> KitIdkits { get; set; } = new List<Kit>();
}
