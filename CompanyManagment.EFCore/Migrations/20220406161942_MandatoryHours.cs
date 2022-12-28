using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class MandatoryHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MandatoryHoursid",
                table: "Contracts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MandatoryHours",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Farvardin = table.Column<double>(type: "float", nullable: false),
                    Ordibehesht = table.Column<double>(type: "float", nullable: false),
                    Khordad = table.Column<double>(type: "float", nullable: false),
                    Tir = table.Column<double>(type: "float", nullable: false),
                    Mordad = table.Column<double>(type: "float", nullable: false),
                    Shahrivar = table.Column<double>(type: "float", nullable: false),
                    Mehr = table.Column<double>(type: "float", nullable: false),
                    Aban = table.Column<double>(type: "float", nullable: false),
                    Azar = table.Column<double>(type: "float", nullable: false),
                    Dey = table.Column<double>(type: "float", nullable: false),
                    Bahman = table.Column<double>(type: "float", nullable: false),
                    Esfand = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandatoryHours", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MandatoryHoursid",
                table: "Contracts",
                column: "MandatoryHoursid");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_MandatoryHours_MandatoryHoursid",
                table: "Contracts",
                column: "MandatoryHoursid",
                principalTable: "MandatoryHours",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_MandatoryHours_MandatoryHoursid",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "MandatoryHours");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_MandatoryHoursid",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "MandatoryHoursid",
                table: "Contracts");
        }
    }
}
