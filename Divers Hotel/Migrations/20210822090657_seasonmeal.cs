using Microsoft.EntityFrameworkCore.Migrations;

namespace Divers_Hotel.Migrations
{
    public partial class seasonmeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_MealSeasons_MealSeasonId",
                table: "MealPlans");

            migrationBuilder.DropIndex(
                name: "IX_MealPlans_MealSeasonId",
                table: "MealPlans");

            migrationBuilder.DropColumn(
                name: "MealSeasonId",
                table: "MealPlans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealSeasonId",
                table: "MealPlans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_MealSeasonId",
                table: "MealPlans",
                column: "MealSeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_MealSeasons_MealSeasonId",
                table: "MealPlans",
                column: "MealSeasonId",
                principalTable: "MealSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
