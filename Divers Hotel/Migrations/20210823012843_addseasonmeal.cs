using Microsoft.EntityFrameworkCore.Migrations;

namespace Divers_Hotel.Migrations
{
    public partial class addseasonmeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameSeason",
                table: "MealSeasons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameSeason",
                table: "MealSeasons");
        }
    }
}
