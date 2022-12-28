using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class Subtitle_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subtitles_Id",
                table: "TextManager_TextManager",
                newName: "Subtitle_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subtitle_Id",
                table: "TextManager_TextManager",
                newName: "Subtitles_Id");
        }
    }
}
