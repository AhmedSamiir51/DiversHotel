using Microsoft.EntityFrameworkCore.Migrations;

namespace Divers_Hotel.Migrations
{
    public partial class loggin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoggin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoggin",
                table: "Users");
        }
    }
}
