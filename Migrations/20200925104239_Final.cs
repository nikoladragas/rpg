using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_core_rpg.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Damage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Role = table.Column<string>(nullable: false, defaultValue: "Player")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    HitPoints = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Defuse = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Class = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => new { x.CharacterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Damage = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[,]
                {
                    { 1, 30, "Fireball" },
                    { 2, 20, "Blizzard" },
                    { 3, 50, "Frenzy" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[,]
                {
                    { 1, new byte[] { 251, 209, 112, 134, 217, 142, 134, 106, 36, 185, 160, 1, 24, 98, 12, 209, 182, 71, 233, 62, 114, 135, 103, 248, 167, 200, 142, 227, 94, 97, 84, 187, 171, 194, 197, 255, 169, 133, 143, 211, 129, 45, 227, 6, 145, 237, 68, 119, 116, 160, 195, 45, 139, 66, 32, 127, 185, 121, 238, 124, 67, 41, 226, 9 }, new byte[] { 200, 240, 212, 184, 203, 92, 182, 166, 15, 235, 25, 131, 48, 135, 6, 243, 240, 189, 178, 25, 41, 249, 120, 90, 249, 144, 30, 252, 171, 6, 134, 130, 150, 4, 152, 222, 113, 180, 150, 113, 101, 77, 239, 117, 152, 126, 92, 202, 17, 64, 75, 135, 42, 117, 174, 211, 241, 75, 85, 55, 2, 97, 62, 58, 207, 199, 107, 142, 189, 175, 166, 76, 26, 53, 122, 24, 248, 200, 250, 155, 58, 124, 176, 4, 79, 108, 165, 138, 122, 190, 104, 46, 200, 45, 130, 59, 20, 191, 154, 68, 219, 120, 196, 232, 205, 61, 76, 246, 97, 55, 49, 145, 240, 17, 191, 25, 16, 237, 243, 254, 106, 37, 183, 112, 100, 127, 35, 10 }, "user1" },
                    { 2, new byte[] { 251, 209, 112, 134, 217, 142, 134, 106, 36, 185, 160, 1, 24, 98, 12, 209, 182, 71, 233, 62, 114, 135, 103, 248, 167, 200, 142, 227, 94, 97, 84, 187, 171, 194, 197, 255, 169, 133, 143, 211, 129, 45, 227, 6, 145, 237, 68, 119, 116, 160, 195, 45, 139, 66, 32, 127, 185, 121, 238, 124, 67, 41, 226, 9 }, new byte[] { 200, 240, 212, 184, 203, 92, 182, 166, 15, 235, 25, 131, 48, 135, 6, 243, 240, 189, 178, 25, 41, 249, 120, 90, 249, 144, 30, 252, 171, 6, 134, 130, 150, 4, 152, 222, 113, 180, 150, 113, 101, 77, 239, 117, 152, 126, 92, 202, 17, 64, 75, 135, 42, 117, 174, 211, 241, 75, 85, 55, 2, 97, 62, 58, 207, 199, 107, 142, 189, 175, 166, 76, 26, 53, 122, 24, 248, 200, 250, 155, 58, 124, 176, 4, 79, 108, 165, 138, 122, 190, 104, 46, 200, 45, 130, 59, 20, 191, 154, 68, 219, 120, 196, 232, 205, 61, 76, 246, 97, 55, 49, 145, 240, 17, 191, 25, 16, 237, 243, 254, 106, 37, 183, 112, 100, 127, 35, 10 }, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defuse", "HitPoints", "Intelligence", "Name", "Strength", "UserId" },
                values: new object[] { 1, 1, 10, 100, 10, "Frodo", 15, 1 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defuse", "HitPoints", "Intelligence", "Name", "Strength", "UserId" },
                values: new object[] { 2, 2, 15, 50, 20, "Raistlin", 30, 2 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[,]
                {
                    { 1, 1, 20, "Master Sword" },
                    { 2, 2, 30, "Crystal Wand" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillId",
                table: "CharacterSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
