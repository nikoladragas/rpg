namespace dotnet_core_rpg.Models
{
    public class CharacterSkill
    {
      public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; } 

    }
}