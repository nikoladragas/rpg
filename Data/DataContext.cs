using dotnet_core_rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_core_rpg.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
          modelBuilder.Entity<CharacterSkill>()
            .HasKey(cs => new { cs.CharacterId, cs.SkillId});

          modelBuilder.Entity<User>()
            .Property(user => user.Role).HasDefaultValue("Player");
          
          
          modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, Name = "Fireball", Damage = 30},
            new Skill { Id = 2, Name = "Blizzard", Damage = 20},
            new Skill { Id = 3, Name = "Frenzy", Damage = 50}
          );

          Utility.CreatePasswordHash("NidzinPass9!", out byte[] passwordHash, out byte[] passwordSalt);

          modelBuilder.Entity<User>().HasData(
            new User { Id = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "user1"},
            new User { Id = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "user2"}
          );

          modelBuilder.Entity<Character>().HasData(
            new Character {
              Id = 1,
              Name = "Frodo",
              Class = RpgClass.Knight,
              HitPoints = 100,
              Strength = 15,
              Defuse = 10,
              Intelligence = 10,
              UserId = 1
             },
            new Character {
            Id = 2,
            Name = "Raistlin",
            Class = RpgClass.Mage,
            HitPoints = 50,
            Strength = 30,
            Defuse = 15,
            Intelligence = 20,
            UserId = 2
            }
          );

          modelBuilder.Entity<Weapon>().HasData(
            new Weapon { Id = 1, Name = "Master Sword", Damage = 20, CharacterId = 1 },
            new Weapon { Id = 2, Name = "Crystal Wand", Damage = 30, CharacterId = 2 }
          );

          modelBuilder.Entity<CharacterSkill>().HasData(
            new CharacterSkill { CharacterId = 1, SkillId = 2},
            new CharacterSkill { CharacterId = 2, SkillId = 1},
            new CharacterSkill { CharacterId = 2, SkillId = 3}
          );  
        }
    }
}