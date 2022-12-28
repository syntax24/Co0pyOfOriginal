using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class add_Master_Petition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Master_Petitions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkHistoryDescreption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardType_Id = table.Column<int>(type: "int", nullable: false),
                    File_Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Petitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Master_Petitions_BoardTypes_BoardType_Id",
                        column: x => x.BoardType_Id,
                        principalTable: "BoardTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Master_Petitions_Files_File_Id",
                        column: x => x.File_Id,
                        principalTable: "Files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Master_PenaltyTitles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPetition_Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_PenaltyTitles", x => x.id);
                    table.ForeignKey(
                        name: "FK_Master_PenaltyTitles_Master_Petitions_MasterPetition_Id",
                        column: x => x.MasterPetition_Id,
                        principalTable: "Master_Petitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Master_WorkHistories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkingHoursPerDay = table.Column<int>(type: "int", nullable: true),
                    WorkingHoursPerWeek = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPetition_Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_WorkHistories", x => x.id);
                    table.ForeignKey(
                        name: "FK_Master_WorkHistories_Master_Petitions_MasterPetition_Id",
                        column: x => x.MasterPetition_Id,
                        principalTable: "Master_Petitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Master_PenaltyTitles_MasterPetition_Id",
                table: "Master_PenaltyTitles",
                column: "MasterPetition_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Master_Petitions_BoardType_Id",
                table: "Master_Petitions",
                column: "BoardType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Master_Petitions_File_Id",
                table: "Master_Petitions",
                column: "File_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Master_WorkHistories_MasterPetition_Id",
                table: "Master_WorkHistories",
                column: "MasterPetition_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Master_PenaltyTitles");

            migrationBuilder.DropTable(
                name: "Master_WorkHistories");

            migrationBuilder.DropTable(
                name: "Master_Petitions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Files");
        }
    }
}
