using System;
using System.Collections.Generic;
using DBConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace DBConnection.Data;

public partial class CreatorDbContext : DbContext
{
    public static string? currentUser { get; set; }
    public CreatorDbContext()
    {
    }

    public CreatorDbContext(DbContextOptions<CreatorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Armor> Armors { get; set; }

    public virtual DbSet<ArmorType> ArmorTypes { get; set; }

    public virtual DbSet<Background> Backgrounds { get; set; }

    public virtual DbSet<BackgroundSkill> BackgroundSkills { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharacterTrait> CharacterTraits { get; set; }

    public virtual DbSet<Characteristic> Characteristics { get; set; }

    public virtual DbSet<CharacteristicCharacter> CharacteristicCharacters { get; set; }

    public virtual DbSet<CharacteristicSkill> CharacteristicSkills { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassSkill> ClassSkills { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Devotion> Devotions { get; set; }

    public virtual DbSet<Distance> Distances { get; set; }

    public virtual DbSet<Durance> Durances { get; set; }

    public virtual DbSet<Focus> Foci { get; set; }

    public virtual DbSet<Ideology> Ideologies { get; set; }

    public virtual DbSet<Idial> Idials { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Kit> Kits { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Spell> Spells { get; set; }

    public virtual DbSet<TimeSpell> TimeSpells { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Weakness> Weaknesses { get; set; }

    public virtual DbSet<Weapon> Weapons { get; set; }

    public virtual DbSet<WeaponType> WeaponTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=192.168.0.46;port=3306;user=user;password=pass;database=creatordb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Armor>(entity =>
        {
            entity.HasKey(e => e.IdArmor).HasName("PRIMARY");

            entity.ToTable("armor");

            entity.HasIndex(e => e.ArmorTypeIdarmorType, "fk_armor_armor_type_idx");

            entity.Property(e => e.IdArmor).HasColumnName("id_armor");
            entity.Property(e => e.ArmorClass).HasColumnName("armor_class");
            entity.Property(e => e.ArmorTypeIdarmorType).HasColumnName("armor_type_idarmor_type");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(8)
                .HasColumnName("price");
            entity.Property(e => e.Weight)
                .HasPrecision(5)
                .HasColumnName("weight");

            entity.HasOne(d => d.ArmorTypeIdarmorTypeNavigation).WithMany(p => p.Armors)
                .HasForeignKey(d => d.ArmorTypeIdarmorType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_armor_armor_type");

            entity.HasMany(d => d.ClassIdclasses).WithMany(p => p.ArmorIdarmors)
                .UsingEntity<Dictionary<string, object>>(
                    "ArmorClass",
                    r => r.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassIdclass")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_armor_has_class_class1"),
                    l => l.HasOne<Armor>().WithMany()
                        .HasForeignKey("ArmorIdarmor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_armor_has_class_armor1"),
                    j =>
                    {
                        j.HasKey("ArmorIdarmor", "ClassIdclass").HasName("PRIMARY");
                        j.ToTable("armor_class");
                        j.HasIndex(new[] { "ArmorIdarmor" }, "fk_armor_has_class_armor1_idx");
                        j.HasIndex(new[] { "ClassIdclass" }, "fk_armor_has_class_class1_idx");
                        j.IndexerProperty<int>("ArmorIdarmor").HasColumnName("armor_idarmor");
                        j.IndexerProperty<int>("ClassIdclass").HasColumnName("class_idclass");
                    });
        });

        modelBuilder.Entity<ArmorType>(entity =>
        {
            entity.HasKey(e => e.IdArmorType).HasName("PRIMARY");

            entity.ToTable("armor_type");

            entity.Property(e => e.IdArmorType).HasColumnName("id_armor_type");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Background>(entity =>
        {
            entity.HasKey(e => e.IdBackground).HasName("PRIMARY");

            entity.ToTable("background");

            entity.Property(e => e.IdBackground).HasColumnName("id_background");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");

            entity.HasMany(d => d.InstrumentIdInstruments).WithMany(p => p.BackgroundIdBackgrounds)
                .UsingEntity<Dictionary<string, object>>(
                    "BackgroundInstrument",
                    r => r.HasOne<Instrument>().WithMany()
                        .HasForeignKey("InstrumentIdInstrument")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_background_has_instrument_instrument1"),
                    l => l.HasOne<Background>().WithMany()
                        .HasForeignKey("BackgroundIdBackground")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_background_has_instrument_background1"),
                    j =>
                    {
                        j.HasKey("BackgroundIdBackground", "InstrumentIdInstrument").HasName("PRIMARY");
                        j.ToTable("background_instrument");
                        j.HasIndex(new[] { "BackgroundIdBackground" }, "fk_background_has_instrument_background1_idx");
                        j.HasIndex(new[] { "InstrumentIdInstrument" }, "fk_background_has_instrument_instrument1_idx");
                        j.IndexerProperty<int>("BackgroundIdBackground").HasColumnName("background_id_background");
                        j.IndexerProperty<int>("InstrumentIdInstrument").HasColumnName("instrument_id_instrument");
                    });

            entity.HasMany(d => d.KitIdkits).WithMany(p => p.BackgroundIdbackgrounds)
                .UsingEntity<Dictionary<string, object>>(
                    "BackgroundKit",
                    r => r.HasOne<Kit>().WithMany()
                        .HasForeignKey("KitIdkit")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_background_has_kit_kit1"),
                    l => l.HasOne<Background>().WithMany()
                        .HasForeignKey("BackgroundIdbackground")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_background_has_kit_background1"),
                    j =>
                    {
                        j.HasKey("BackgroundIdbackground", "KitIdkit").HasName("PRIMARY");
                        j.ToTable("background_kit");
                        j.HasIndex(new[] { "BackgroundIdbackground" }, "fk_background_has_kit_background1_idx");
                        j.HasIndex(new[] { "KitIdkit" }, "fk_background_has_kit_kit1_idx");
                        j.IndexerProperty<int>("BackgroundIdbackground").HasColumnName("background_idbackground");
                        j.IndexerProperty<int>("KitIdkit").HasColumnName("kit_idkit");
                    });
        });

        modelBuilder.Entity<BackgroundSkill>(entity =>
        {
            entity.HasKey(e => new { e.BackgroundIdBackground, e.SkillIdskill }).HasName("PRIMARY");

            entity.ToTable("background_skill");

            entity.HasIndex(e => e.BackgroundIdBackground, "fk_background_has_skill_background1_idx");

            entity.HasIndex(e => e.SkillIdskill, "fk_background_has_skill_skill1_idx");

            entity.Property(e => e.BackgroundIdBackground).HasColumnName("background_id_background");
            entity.Property(e => e.SkillIdskill).HasColumnName("skill_idskill");
            entity.Property(e => e.Bonus).HasColumnName("bonus");

            entity.HasOne(d => d.BackgroundIdBackgroundNavigation).WithMany(p => p.BackgroundSkills)
                .HasForeignKey(d => d.BackgroundIdBackground)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_background_has_skill_background1");

            entity.HasOne(d => d.SkillIdskillNavigation).WithMany(p => p.BackgroundSkills)
                .HasForeignKey(d => d.SkillIdskill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_background_has_skill_skill1");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.IdCharacter).HasName("PRIMARY");

            entity.ToTable("character");

            entity.HasIndex(e => e.BackgroundIdBackground, "fk_character_background1_idx");

            entity.HasIndex(e => e.ClassIdClass, "fk_character_class1_idx");

            entity.HasIndex(e => e.IdeologyIdIdeology, "fk_character_ideology1_idx");

            entity.HasIndex(e => e.RaceIdRace, "fk_character_race1_idx");

            entity.HasIndex(e => e.UserIduser, "fk_character_user1_idx");

            entity.Property(e => e.IdCharacter).HasColumnName("id_character");
            entity.Property(e => e.Allies)
                .HasColumnType("text")
                .HasColumnName("allies");
            entity.Property(e => e.BackgroundIdBackground).HasColumnName("background_id_background");
            entity.Property(e => e.ClassIdClass).HasColumnName("class_id_class");
            entity.Property(e => e.Hitcount).HasColumnName("hitcount");
            entity.Property(e => e.IdeologyIdIdeology).HasColumnName("ideology_id_ideology");
            entity.Property(e => e.Name)
                .HasMaxLength(155)
                .HasColumnName("name");
            entity.Property(e => e.Otherinformation)
                .HasColumnType("text")
                .HasColumnName("otherinformation");
            entity.Property(e => e.RaceIdRace).HasColumnName("race_id_race");
            entity.Property(e => e.TextBackground)
                .HasColumnType("text")
                .HasColumnName("text_background");
            entity.Property(e => e.UserIduser).HasColumnName("user_iduser");

            entity.HasOne(d => d.BackgroundIdBackgroundNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.BackgroundIdBackground)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_character_background1");

            entity.HasOne(d => d.ClassIdClassNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.ClassIdClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_character_class1");

            entity.HasOne(d => d.IdeologyIdIdeologyNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.IdeologyIdIdeology)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_character_ideology1");

            entity.HasOne(d => d.RaceIdRaceNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.RaceIdRace)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_character_race1");

            entity.HasOne(d => d.UserIduserNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.UserIduser)
                .HasConstraintName("fk_character_user1");
        });

        modelBuilder.Entity<CharacterTrait>(entity =>
        {
            entity.HasKey(e => new { e.IdIdial, e.BackgroundIdBackground }).HasName("PRIMARY");

            entity.ToTable("character_trait");

            entity.HasIndex(e => e.BackgroundIdBackground, "fk_character_trait_background1_idx");

            entity.Property(e => e.IdIdial)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_idial");
            entity.Property(e => e.BackgroundIdBackground).HasColumnName("background_id_background");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");

            entity.HasOne(d => d.BackgroundIdBackgroundNavigation).WithMany(p => p.CharacterTraits)
                .HasForeignKey(d => d.BackgroundIdBackground)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_character_trait_background1");
        });

        modelBuilder.Entity<Characteristic>(entity =>
        {
            entity.HasKey(e => e.IdCharacteristic).HasName("PRIMARY");

            entity.ToTable("characteristic");

            entity.Property(e => e.IdCharacteristic).HasColumnName("id_characteristic");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CharacteristicCharacter>(entity =>
        {
            entity.HasKey(e => new { e.CharacteristicIdCharacteristic, e.CharacterIdCharacter }).HasName("PRIMARY");

            entity.ToTable("characteristic_character");

            entity.HasIndex(e => e.CharacterIdCharacter, "fk_characteristic_has_character_character1_idx");

            entity.HasIndex(e => e.CharacteristicIdCharacteristic, "fk_characteristic_has_character_characteristic1_idx");

            entity.Property(e => e.CharacteristicIdCharacteristic).HasColumnName("characteristic_id_characteristic");
            entity.Property(e => e.CharacterIdCharacter).HasColumnName("character_id_character");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.CharacterIdCharacterNavigation).WithMany(p => p.CharacteristicCharacters)
                .HasForeignKey(d => d.CharacterIdCharacter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_characteristic_has_character_character1");

            entity.HasOne(d => d.CharacteristicIdCharacteristicNavigation).WithMany(p => p.CharacteristicCharacters)
                .HasForeignKey(d => d.CharacteristicIdCharacteristic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_characteristic_has_character_characteristic1");
        });

        modelBuilder.Entity<CharacteristicSkill>(entity =>
        {
            entity.HasKey(e => new { e.CharacteristicIdcharacteristic, e.SkillIdSkill }).HasName("PRIMARY");

            entity.ToTable("characteristic_skill");

            entity.HasIndex(e => e.CharacteristicIdcharacteristic, "fk_characteristic_has_skill_characteristic1_idx");

            entity.HasIndex(e => e.SkillIdSkill, "fk_characteristic_has_skill_skill1_idx");

            entity.Property(e => e.CharacteristicIdcharacteristic).HasColumnName("characteristic_idcharacteristic");
            entity.Property(e => e.SkillIdSkill).HasColumnName("skill_id_skill");
            entity.Property(e => e.Bonus).HasColumnName("bonus");

            entity.HasOne(d => d.CharacteristicIdcharacteristicNavigation).WithMany(p => p.CharacteristicSkills)
                .HasForeignKey(d => d.CharacteristicIdcharacteristic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_characteristic_has_skill_characteristic1");

            entity.HasOne(d => d.SkillIdSkillNavigation).WithMany(p => p.CharacteristicSkills)
                .HasForeignKey(d => d.SkillIdSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_characteristic_has_skill_skill1");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.IdClass).HasName("PRIMARY");

            entity.ToTable("class");

            entity.Property(e => e.IdClass).HasColumnName("id_class");
            entity.Property(e => e.FocusCount).HasColumnName("focus_count");
            entity.Property(e => e.HitModificator).HasColumnName("hit_modificator");
            entity.Property(e => e.IconPath)
                .HasColumnType("text")
                .HasColumnName("icon_path");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Spellcount).HasColumnName("spellcount");

            entity.HasMany(d => d.FocusIdfoci).WithMany(p => p.ClassIdclasses)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassFocus",
                    r => r.HasOne<Focus>().WithMany()
                        .HasForeignKey("FocusIdfocus")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_class_has_focus_focus1"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassIdclass")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_class_has_focus_class1"),
                    j =>
                    {
                        j.HasKey("ClassIdclass", "FocusIdfocus").HasName("PRIMARY");
                        j.ToTable("class_focus");
                        j.HasIndex(new[] { "ClassIdclass" }, "fk_class_has_focus_class1_idx");
                        j.HasIndex(new[] { "FocusIdfocus" }, "fk_class_has_focus_focus1_idx");
                        j.IndexerProperty<int>("ClassIdclass").HasColumnName("class_idclass");
                        j.IndexerProperty<int>("FocusIdfocus").HasColumnName("focus_idfocus");
                    });

            entity.HasMany(d => d.InstrumentIdInstruments).WithMany(p => p.ClassIdClasses)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassInstrument",
                    r => r.HasOne<Instrument>().WithMany()
                        .HasForeignKey("InstrumentIdInstrument")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_class_has_instrument_instrument1"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassIdClass")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_class_has_instrument_class1"),
                    j =>
                    {
                        j.HasKey("ClassIdClass", "InstrumentIdInstrument").HasName("PRIMARY");
                        j.ToTable("class_instrument");
                        j.HasIndex(new[] { "ClassIdClass" }, "fk_class_has_instrument_class1_idx");
                        j.HasIndex(new[] { "InstrumentIdInstrument" }, "fk_class_has_instrument_instrument1_idx");
                        j.IndexerProperty<int>("ClassIdClass").HasColumnName("class_id_class");
                        j.IndexerProperty<int>("InstrumentIdInstrument").HasColumnName("instrument_id_instrument");
                    });

            entity.HasMany(d => d.SpellIdspells).WithMany(p => p.ClassIdclasses)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassSpell",
                    r => r.HasOne<Spell>().WithMany()
                        .HasForeignKey("SpellIdspell")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_class_has_spell_spell1"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassIdclass")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_class_has_spell_class1"),
                    j =>
                    {
                        j.HasKey("ClassIdclass", "SpellIdspell").HasName("PRIMARY");
                        j.ToTable("class_spell");
                        j.HasIndex(new[] { "ClassIdclass" }, "fk_class_has_spell_class1_idx");
                        j.HasIndex(new[] { "SpellIdspell" }, "fk_class_has_spell_spell1_idx");
                        j.IndexerProperty<int>("ClassIdclass").HasColumnName("class_idclass");
                        j.IndexerProperty<int>("SpellIdspell").HasColumnName("spell_idspell");
                    });
        });

        modelBuilder.Entity<ClassSkill>(entity =>
        {
            entity.HasKey(e => new { e.ClassIdClass, e.SkillIdSkill }).HasName("PRIMARY");

            entity.ToTable("class_skill");

            entity.HasIndex(e => e.ClassIdClass, "fk_class_has_skill_class1_idx");

            entity.HasIndex(e => e.SkillIdSkill, "fk_class_has_skill_skill1_idx");

            entity.Property(e => e.ClassIdClass).HasColumnName("class_id_class");
            entity.Property(e => e.SkillIdSkill).HasColumnName("skill_id_skill");
            entity.Property(e => e.Bonus).HasColumnName("bonus");

            entity.HasOne(d => d.ClassIdClassNavigation).WithMany(p => p.ClassSkills)
                .HasForeignKey(d => d.ClassIdClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_class_has_skill_class1");

            entity.HasOne(d => d.SkillIdSkillNavigation).WithMany(p => p.ClassSkills)
                .HasForeignKey(d => d.SkillIdSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_class_has_skill_skill1");
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(e => e.IdComponent).HasName("PRIMARY");

            entity.ToTable("component");

            entity.Property(e => e.IdComponent).HasColumnName("id_component");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Devotion>(entity =>
        {
            entity.HasKey(e => new { e.IdDevotion, e.BackgroundIdBackground }).HasName("PRIMARY");

            entity.ToTable("devotion");

            entity.HasIndex(e => e.BackgroundIdBackground, "fk_devotion_background1_idx");

            entity.Property(e => e.IdDevotion).HasColumnName("id_devotion");
            entity.Property(e => e.BackgroundIdBackground).HasColumnName("background_id_background");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");

            entity.HasOne(d => d.BackgroundIdBackgroundNavigation).WithMany(p => p.Devotions)
                .HasForeignKey(d => d.BackgroundIdBackground)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_devotion_background1");
        });

        modelBuilder.Entity<Distance>(entity =>
        {
            entity.HasKey(e => e.IdDistance).HasName("PRIMARY");

            entity.ToTable("distance");

            entity.Property(e => e.IdDistance).HasColumnName("id_distance");
            entity.Property(e => e.Distance1)
                .HasColumnType("text")
                .HasColumnName("distance");
        });

        modelBuilder.Entity<Durance>(entity =>
        {
            entity.HasKey(e => e.IdDurance).HasName("PRIMARY");

            entity.ToTable("durance");

            entity.Property(e => e.IdDurance).HasColumnName("id_durance");
            entity.Property(e => e.Durance1)
                .HasColumnType("text")
                .HasColumnName("durance");
        });

        modelBuilder.Entity<Focus>(entity =>
        {
            entity.HasKey(e => e.IdFocus).HasName("PRIMARY");

            entity.ToTable("focus");

            entity.Property(e => e.IdFocus).HasColumnName("id_focus");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");

            entity.HasMany(d => d.ComponentIdComponents).WithMany(p => p.FocusIdFoci)
                .UsingEntity<Dictionary<string, object>>(
                    "FocusComponent",
                    r => r.HasOne<Component>().WithMany()
                        .HasForeignKey("ComponentIdComponent")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_focus_has_component_component1"),
                    l => l.HasOne<Focus>().WithMany()
                        .HasForeignKey("FocusIdFocus")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_focus_has_component_focus1"),
                    j =>
                    {
                        j.HasKey("FocusIdFocus", "ComponentIdComponent").HasName("PRIMARY");
                        j.ToTable("focus_component");
                        j.HasIndex(new[] { "ComponentIdComponent" }, "fk_focus_has_component_component1_idx");
                        j.HasIndex(new[] { "FocusIdFocus" }, "fk_focus_has_component_focus1_idx");
                        j.IndexerProperty<int>("FocusIdFocus").HasColumnName("focus_id_focus");
                        j.IndexerProperty<int>("ComponentIdComponent").HasColumnName("component_id_component");
                    });

            entity.HasMany(d => d.DistanceIdDistances).WithMany(p => p.FocusIdFoci)
                .UsingEntity<Dictionary<string, object>>(
                    "FocusDistance",
                    r => r.HasOne<Distance>().WithMany()
                        .HasForeignKey("DistanceIdDistance")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_focus_has_distance_distance1"),
                    l => l.HasOne<Focus>().WithMany()
                        .HasForeignKey("FocusIdFocus")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_focus_has_distance_focus1"),
                    j =>
                    {
                        j.HasKey("FocusIdFocus", "DistanceIdDistance").HasName("PRIMARY");
                        j.ToTable("focus_distance");
                        j.HasIndex(new[] { "DistanceIdDistance" }, "fk_focus_has_distance_distance1_idx");
                        j.HasIndex(new[] { "FocusIdFocus" }, "fk_focus_has_distance_focus1_idx");
                        j.IndexerProperty<int>("FocusIdFocus").HasColumnName("focus_id_focus");
                        j.IndexerProperty<int>("DistanceIdDistance").HasColumnName("distance_id_distance");
                    });

            entity.HasMany(d => d.DuranceIdDurances).WithMany(p => p.FocusIdFoci)
                .UsingEntity<Dictionary<string, object>>(
                    "FocusDurance",
                    r => r.HasOne<Durance>().WithMany()
                        .HasForeignKey("DuranceIdDurance")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_focus_has_durance_durance1"),
                    l => l.HasOne<Focus>().WithMany()
                        .HasForeignKey("FocusIdFocus")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_focus_has_durance_focus1"),
                    j =>
                    {
                        j.HasKey("FocusIdFocus", "DuranceIdDurance").HasName("PRIMARY");
                        j.ToTable("focus_durance");
                        j.HasIndex(new[] { "DuranceIdDurance" }, "fk_focus_has_durance_durance1_idx");
                        j.HasIndex(new[] { "FocusIdFocus" }, "fk_focus_has_durance_focus1_idx");
                        j.IndexerProperty<int>("FocusIdFocus").HasColumnName("focus_id_focus");
                        j.IndexerProperty<int>("DuranceIdDurance").HasColumnName("durance_id_durance");
                    });

            entity.HasMany(d => d.TimeSpellIdTimeSpells).WithMany(p => p.FocusIdFoci)
                .UsingEntity<Dictionary<string, object>>(
                    "FocusTimeSpell",
                    r => r.HasOne<TimeSpell>().WithMany()
                        .HasForeignKey("TimeSpellIdTimeSpell")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_focus_has_time_spell_time_spell1"),
                    l => l.HasOne<Focus>().WithMany()
                        .HasForeignKey("FocusIdFocus")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_focus_has_time_spell_focus1"),
                    j =>
                    {
                        j.HasKey("FocusIdFocus", "TimeSpellIdTimeSpell").HasName("PRIMARY");
                        j.ToTable("focus_time_spell");
                        j.HasIndex(new[] { "FocusIdFocus" }, "fk_focus_has_time_spell_focus1_idx");
                        j.HasIndex(new[] { "TimeSpellIdTimeSpell" }, "fk_focus_has_time_spell_time_spell1_idx");
                        j.IndexerProperty<int>("FocusIdFocus").HasColumnName("focus_id_focus");
                        j.IndexerProperty<int>("TimeSpellIdTimeSpell").HasColumnName("time_spell_id_time_spell");
                    });
        });

        modelBuilder.Entity<Ideology>(entity =>
        {
            entity.HasKey(e => e.IdIdeology).HasName("PRIMARY");

            entity.ToTable("ideology");

            entity.Property(e => e.IdIdeology).HasColumnName("id_ideology");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Idial>(entity =>
        {
            entity.HasKey(e => new { e.IdIdial, e.BackgroundIdBackground }).HasName("PRIMARY");

            entity.ToTable("idial");

            entity.HasIndex(e => e.BackgroundIdBackground, "fk_idial_background1_idx");

            entity.Property(e => e.IdIdial)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_idial");
            entity.Property(e => e.BackgroundIdBackground).HasColumnName("background_id_background");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");

            entity.HasOne(d => d.BackgroundIdBackgroundNavigation).WithMany(p => p.Idials)
                .HasForeignKey(d => d.BackgroundIdBackground)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_idial_background1");
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.IdInstrument).HasName("PRIMARY");

            entity.ToTable("instrument");

            entity.Property(e => e.IdInstrument).HasColumnName("id_instrument");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.IdItem).HasName("PRIMARY");

            entity.ToTable("item");

            entity.Property(e => e.IdItem).HasColumnName("id_item");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(8)
                .HasColumnName("price");
            entity.Property(e => e.Weight)
                .HasPrecision(5)
                .HasColumnName("weight");
        });

        modelBuilder.Entity<Kit>(entity =>
        {
            entity.HasKey(e => e.Idkit).HasName("PRIMARY");

            entity.ToTable("kit");

            entity.Property(e => e.Idkit).HasColumnName("idkit");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(8)
                .HasColumnName("price");

            entity.HasMany(d => d.ItemIditems).WithMany(p => p.KitIdkits)
                .UsingEntity<Dictionary<string, object>>(
                    "KitHasItem",
                    r => r.HasOne<Item>().WithMany()
                        .HasForeignKey("ItemIditem")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_kit_has_item_item1"),
                    l => l.HasOne<Kit>().WithMany()
                        .HasForeignKey("KitIdkit")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_kit_has_item_kit1"),
                    j =>
                    {
                        j.HasKey("KitIdkit", "ItemIditem").HasName("PRIMARY");
                        j.ToTable("kit_has_item");
                        j.HasIndex(new[] { "ItemIditem" }, "fk_kit_has_item_item1_idx");
                        j.HasIndex(new[] { "KitIdkit" }, "fk_kit_has_item_kit1_idx");
                        j.IndexerProperty<int>("KitIdkit").HasColumnName("kit_idkit");
                        j.IndexerProperty<int>("ItemIditem").HasColumnName("item_iditem");
                    });
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Idlanguage).HasName("PRIMARY");

            entity.ToTable("language");

            entity.Property(e => e.Idlanguage).HasColumnName("idlanguage");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");

            entity.HasMany(d => d.RaceIdRaces).WithMany(p => p.LanguageIdLanguages)
                .UsingEntity<Dictionary<string, object>>(
                    "RaceLanguage",
                    r => r.HasOne<Race>().WithMany()
                        .HasForeignKey("RaceIdRace")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_language_has_race_race1"),
                    l => l.HasOne<Language>().WithMany()
                        .HasForeignKey("LanguageIdLanguage")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_language_has_race_language1"),
                    j =>
                    {
                        j.HasKey("LanguageIdLanguage", "RaceIdRace").HasName("PRIMARY");
                        j.ToTable("race_language");
                        j.HasIndex(new[] { "LanguageIdLanguage" }, "fk_language_has_race_language1_idx");
                        j.HasIndex(new[] { "RaceIdRace" }, "fk_language_has_race_race1_idx");
                        j.IndexerProperty<int>("LanguageIdLanguage").HasColumnName("language_id_language");
                        j.IndexerProperty<int>("RaceIdRace").HasColumnName("race_id_race");
                    });
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Idrace).HasName("PRIMARY");

            entity.ToTable("race");

            entity.Property(e => e.Idrace).HasColumnName("idrace");
            entity.Property(e => e.History)
                .HasColumnType("text")
                .HasColumnName("history");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Peculiarities)
                .HasColumnType("text")
                .HasColumnName("peculiarities");
            entity.Property(e => e.Speed).HasColumnName("speed");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.IdSkill).HasName("PRIMARY");

            entity.ToTable("skill");

            entity.Property(e => e.IdSkill).HasColumnName("id_skill");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Spell>(entity =>
        {
            entity.HasKey(e => e.Idspell).HasName("PRIMARY");

            entity.ToTable("spell");

            entity.Property(e => e.Idspell).HasColumnName("idspell");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(65)
                .HasColumnName("name");

            entity.HasMany(d => d.IdComponents).WithMany(p => p.IdSpells)
                .UsingEntity<Dictionary<string, object>>(
                    "SpellComponent",
                    r => r.HasOne<Component>().WithMany()
                        .HasForeignKey("IdComponent")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_spell_has_component_component1"),
                    l => l.HasOne<Spell>().WithMany()
                        .HasForeignKey("IdSpell")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_spell_has_component_spell1"),
                    j =>
                    {
                        j.HasKey("IdSpell", "IdComponent").HasName("PRIMARY");
                        j.ToTable("spell_component");
                        j.HasIndex(new[] { "IdComponent" }, "fk_spell_has_component_component1_idx");
                        j.HasIndex(new[] { "IdSpell" }, "fk_spell_has_component_spell1_idx");
                        j.IndexerProperty<int>("IdSpell").HasColumnName("id_spell");
                        j.IndexerProperty<int>("IdComponent").HasColumnName("id_component");
                    });

            entity.HasMany(d => d.IdDistances).WithMany(p => p.IdSpells)
                .UsingEntity<Dictionary<string, object>>(
                    "SpellDistance",
                    r => r.HasOne<Distance>().WithMany()
                        .HasForeignKey("IdDistance")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_spell_has_distance_distance1"),
                    l => l.HasOne<Spell>().WithMany()
                        .HasForeignKey("IdSpell")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_spell_has_distance_spell1"),
                    j =>
                    {
                        j.HasKey("IdSpell", "IdDistance").HasName("PRIMARY");
                        j.ToTable("spell_distance");
                        j.HasIndex(new[] { "IdDistance" }, "fk_spell_has_distance_distance1_idx");
                        j.HasIndex(new[] { "IdSpell" }, "fk_spell_has_distance_spell1_idx");
                        j.IndexerProperty<int>("IdSpell").HasColumnName("id_spell");
                        j.IndexerProperty<int>("IdDistance").HasColumnName("id_distance");
                    });

            entity.HasMany(d => d.IdDurances).WithMany(p => p.IdSpells)
                .UsingEntity<Dictionary<string, object>>(
                    "SpellDurance",
                    r => r.HasOne<Durance>().WithMany()
                        .HasForeignKey("IdDurance")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_spell_has_durance_durance1"),
                    l => l.HasOne<Spell>().WithMany()
                        .HasForeignKey("IdSpell")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_spell_has_durance_spell1"),
                    j =>
                    {
                        j.HasKey("IdSpell", "IdDurance").HasName("PRIMARY");
                        j.ToTable("spell_durance");
                        j.HasIndex(new[] { "IdDurance" }, "fk_spell_has_durance_durance1_idx");
                        j.HasIndex(new[] { "IdSpell" }, "fk_spell_has_durance_spell1_idx");
                        j.IndexerProperty<int>("IdSpell").HasColumnName("Id_spell");
                        j.IndexerProperty<int>("IdDurance").HasColumnName("id_durance");
                    });

            entity.HasMany(d => d.IdTimeSpells).WithMany(p => p.IdSpells)
                .UsingEntity<Dictionary<string, object>>(
                    "SpellTime",
                    r => r.HasOne<TimeSpell>().WithMany()
                        .HasForeignKey("IdTimeSpell")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_spell_has_time_spell_time_spell1"),
                    l => l.HasOne<Spell>().WithMany()
                        .HasForeignKey("IdSpell")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_spell_has_time_spell_spell1"),
                    j =>
                    {
                        j.HasKey("IdSpell", "IdTimeSpell").HasName("PRIMARY");
                        j.ToTable("spell_time");
                        j.HasIndex(new[] { "IdSpell" }, "fk_spell_has_time_spell_spell1_idx");
                        j.HasIndex(new[] { "IdTimeSpell" }, "fk_spell_has_time_spell_time_spell1_idx");
                        j.IndexerProperty<int>("IdSpell").HasColumnName("id_spell");
                        j.IndexerProperty<int>("IdTimeSpell").HasColumnName("id_time_spell");
                    });
        });

        modelBuilder.Entity<TimeSpell>(entity =>
        {
            entity.HasKey(e => e.IdTimeSpell).HasName("PRIMARY");

            entity.ToTable("time_spell");

            entity.Property(e => e.IdTimeSpell).HasColumnName("id_time_spell");
            entity.Property(e => e.Time)
                .HasColumnType("text")
                .HasColumnName("time");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Weakness>(entity =>
        {
            entity.HasKey(e => new { e.IdWeakness, e.BackgroundIdBackground }).HasName("PRIMARY");

            entity.ToTable("weakness");

            entity.HasIndex(e => e.BackgroundIdBackground, "fk_weakness_background1_idx");

            entity.Property(e => e.IdWeakness)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_weakness");
            entity.Property(e => e.BackgroundIdBackground).HasColumnName("background_id_background");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");

            entity.HasOne(d => d.BackgroundIdBackgroundNavigation).WithMany(p => p.Weaknesses)
                .HasForeignKey(d => d.BackgroundIdBackground)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_weakness_background1");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.IdWeapon).HasName("PRIMARY");

            entity.ToTable("weapon");

            entity.Property(e => e.IdWeapon).HasColumnName("id_weapon");
            entity.Property(e => e.Damage)
                .HasMaxLength(9)
                .HasColumnName("damage");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(8)
                .HasColumnName("price");
            entity.Property(e => e.Weight)
                .HasPrecision(5)
                .HasColumnName("weight");

            entity.HasMany(d => d.ClassIdClasses).WithMany(p => p.WeaponIdWeapons)
                .UsingEntity<Dictionary<string, object>>(
                    "WeaponClass",
                    r => r.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassIdClass")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_weapon_has_class_class1"),
                    l => l.HasOne<Weapon>().WithMany()
                        .HasForeignKey("WeaponIdWeapon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_weapon_has_class_weapon1"),
                    j =>
                    {
                        j.HasKey("WeaponIdWeapon", "ClassIdClass").HasName("PRIMARY");
                        j.ToTable("weapon_class");
                        j.HasIndex(new[] { "ClassIdClass" }, "fk_weapon_has_class_class1_idx");
                        j.HasIndex(new[] { "WeaponIdWeapon" }, "fk_weapon_has_class_weapon1_idx");
                        j.IndexerProperty<int>("WeaponIdWeapon").HasColumnName("weapon_id_weapon");
                        j.IndexerProperty<int>("ClassIdClass").HasColumnName("class_id_class");
                    });

            entity.HasMany(d => d.WeaponTypeIdweaponTypes).WithMany(p => p.WeaponIdweapons)
                .UsingEntity<Dictionary<string, object>>(
                    "WeaponsType",
                    r => r.HasOne<WeaponType>().WithMany()
                        .HasForeignKey("WeaponTypeIdweaponType")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_weapon_has_weapon_type_weapon_type1"),
                    l => l.HasOne<Weapon>().WithMany()
                        .HasForeignKey("WeaponIdweapon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_weapon_has_weapon_type_weapon1"),
                    j =>
                    {
                        j.HasKey("WeaponIdweapon", "WeaponTypeIdweaponType").HasName("PRIMARY");
                        j.ToTable("weapons_types");
                        j.HasIndex(new[] { "WeaponIdweapon" }, "fk_weapon_has_weapon_type_weapon1_idx");
                        j.HasIndex(new[] { "WeaponTypeIdweaponType" }, "fk_weapon_has_weapon_type_weapon_type1_idx");
                        j.IndexerProperty<int>("WeaponIdweapon").HasColumnName("weapon_idweapon");
                        j.IndexerProperty<int>("WeaponTypeIdweaponType").HasColumnName("weapon_type_idweapon_type");
                    });
        });

        modelBuilder.Entity<WeaponType>(entity =>
        {
            entity.HasKey(e => e.IdweaponType).HasName("PRIMARY");

            entity.ToTable("weapon_type");

            entity.Property(e => e.IdweaponType).HasColumnName("idweapon_type");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
