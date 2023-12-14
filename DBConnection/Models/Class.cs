using System;
using System.Collections.Generic;

namespace DBConnection.Models;

public partial class Class
{
    public int IdClass { get; set; }

    public sbyte FocusCount { get; set; }

    public sbyte Spellcount { get; set; }

    public sbyte HitModificator { get; set; }

    public string Name { get; set; } = null!;

    public string IconPath { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual ICollection<ClassSkill> ClassSkills { get; set; } = new List<ClassSkill>();

    public virtual ICollection<Armor> ArmorIdarmors { get; set; } = new List<Armor>();

    public virtual ICollection<Focus> FocusIdfoci { get; set; } = new List<Focus>();

    public virtual ICollection<Instrument> InstrumentIdInstruments { get; set; } = new List<Instrument>();

    public virtual ICollection<Spell> SpellIdspells { get; set; } = new List<Spell>();

    public virtual ICollection<Weapon> WeaponIdWeapons { get; set; } = new List<Weapon>();
}
