using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class kjkdjlkl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TextManager_Bill");

            migrationBuilder.AddColumn<string>(
                name: "IsActiveString",
                table: "TextManager_Bill",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveString",
                table: "TextManager_Bill");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "TextManager_Bill",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
