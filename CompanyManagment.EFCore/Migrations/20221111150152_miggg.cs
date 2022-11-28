using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class miggg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TextManager_TextManager");

            migrationBuilder.AddColumn<string>(
                name: "IsActiveString",
                table: "TextManager_TextManager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "TextManager_TextManager",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveString",
                table: "TextManager_TextManager");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "TextManager_TextManager");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "TextManager_TextManager",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
