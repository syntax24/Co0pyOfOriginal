using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class eh1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EntitySubtitleid",
                table: "TextManager_Subtitle",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TextManager_Chapter",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chapter = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Subtitle_Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextManager_Chapter", x => x.id);
                    table.ForeignKey(
                        name: "FK_TextManager_Chapter_TextManager_Subtitle_Subtitle_Id",
                        column: x => x.Subtitle_Id,
                        principalTable: "TextManager_Subtitle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextManager_Subtitle_EntitySubtitleid",
                table: "TextManager_Subtitle",
                column: "EntitySubtitleid");

            migrationBuilder.CreateIndex(
                name: "IX_TextManager_Chapter_Subtitle_Id",
                table: "TextManager_Chapter",
                column: "Subtitle_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextManager_Subtitle_TextManager_Subtitle_EntitySubtitleid",
                table: "TextManager_Subtitle",
                column: "EntitySubtitleid",
                principalTable: "TextManager_Subtitle",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextManager_Subtitle_TextManager_Subtitle_EntitySubtitleid",
                table: "TextManager_Subtitle");

            migrationBuilder.DropTable(
                name: "TextManager_Chapter");

            migrationBuilder.DropIndex(
                name: "IX_TextManager_Subtitle_EntitySubtitleid",
                table: "TextManager_Subtitle");

            migrationBuilder.DropColumn(
                name: "EntitySubtitleid",
                table: "TextManager_Subtitle");
        }
    }
}
