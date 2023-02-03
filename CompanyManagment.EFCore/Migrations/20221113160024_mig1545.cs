using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class mig1545 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsActiveString",
                table: "TextManager_Subtitle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsActiveString",
                table: "TextManager_OriginalTitle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsActiveString",
                table: "TextManager_Module",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsActiveString",
                table: "TextManager_Chapter",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveString",
                table: "TextManager_Subtitle");

            migrationBuilder.DropColumn(
                name: "IsActiveString",
                table: "TextManager_OriginalTitle");

            migrationBuilder.DropColumn(
                name: "IsActiveString",
                table: "TextManager_Module");

            migrationBuilder.DropColumn(
                name: "IsActiveString",
                table: "TextManager_Chapter");
        }
    }
}
