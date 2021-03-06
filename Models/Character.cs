using System.Collections.Generic;

namespace dotnet_core_rpg.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defuse { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        // For when database seeding
        public int UserId { get; set; }
        public User User { get; set; }
        public Weapon Weapon{ get; set; }
        public List<CharacterSkill> CharacterSkills { get; set; }
    }
}