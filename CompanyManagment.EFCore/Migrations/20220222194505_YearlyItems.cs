using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class YearlyItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YearlyItems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ItemValue = table.Column<double>(type: "float", nullable: false),
                    ValueType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ParentConnectionId = table.Column<int>(type: "int", nullable: false),
                    YearlySalaryId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlyItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_YearlyItems_YearlySalariess_YearlySalaryId",
                        column: x => x.YearlySalaryId,
                        principalTable: "YearlySalariess",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YearlyItems_YearlySalaryId",
                table: "YearlyItems",
                column: "YearlySalaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearlyItems");
        }
    }
}
