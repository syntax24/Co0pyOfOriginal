using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class TextManaerAding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextManager_Bill",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectBill = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appointed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessingStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextManager_Bill", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TextManager_Contact",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextManager_Contact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TextManager_Module",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSubModule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextManager_Module", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TextManager_OriginalTitle",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextManager_OriginalTitle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TextManager_TextManager",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteNumber = table.Column<int>(type: "int", nullable: false),
                    SubjectTextManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberTextManager = table.Column<int>(type: "int", nullable: false),
                    DateTextManager = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paragraph = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OriginalTitle_Id = table.Column<long>(type: "bigint", nullable: false),
                    Subtitles_Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextManager_TextManager", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TextManager_Subtitle",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subtitle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    OriginalTitle_Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextManager_Subtitle", x => x.id);
                    table.ForeignKey(
                        name: "FK_TextManager_Subtitle_TextManager_OriginalTitle_OriginalTitle_Id",
                        column: x => x.OriginalTitle_Id,
                        principalTable: "TextManager_OriginalTitle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextManager_ModuleTextManager",
                columns: table => new
                {
                    ModuleId = table.Column<long>(type: "bigint", nullable: false),
                    TextManagerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextManager_ModuleTextManager", x => new { x.TextManagerId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_TextManager_ModuleTextManager_TextManager_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "TextManager_Module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextManager_ModuleTextManager_TextManager_TextManager_TextManagerId",
                        column: x => x.TextManagerId,
                        principalTable: "TextManager_TextManager",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextManager_ModuleTextManager_ModuleId",
                table: "TextManager_ModuleTextManager",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TextManager_Subtitle_OriginalTitle_Id",
                table: "TextManager_Subtitle",
                column: "OriginalTitle_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextManager_Bill");

            migrationBuilder.DropTable(
                name: "TextManager_Contact");

            migrationBuilder.DropTable(
                name: "TextManager_ModuleTextManager");

            migrationBuilder.DropTable(
                name: "TextManager_Subtitle");

            migrationBuilder.DropTable(
                name: "TextManager_Module");

            migrationBuilder.DropTable(
                name: "TextManager_TextManager");

            migrationBuilder.DropTable(
                name: "TextManager_OriginalTitle");
        }
    }
}
