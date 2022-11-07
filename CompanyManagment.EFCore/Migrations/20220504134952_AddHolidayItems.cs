using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class AddHolidayItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Holidayitems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Holidaydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HolidayId = table.Column<long>(type: "bigint", nullable: false),
                    HolidayYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidayitems", x => x.id);
                    table.ForeignKey(
                        name: "FK_Holidayitems_Holidays_HolidayId",
                        column: x => x.HolidayId,
                        principalTable: "Holidays",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holidayitems_HolidayId",
                table: "Holidayitems",
                column: "HolidayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidayitems");
        }
    }
}
