using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_core_rpg.Migrations
{
    public partial class WeaponName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Weapons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Weapons");
        }
    }
}
