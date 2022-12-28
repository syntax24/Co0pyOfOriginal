using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class WorkingHoursItemsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkingHoursItems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWork = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Start1 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    End1 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    RestTime = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Start2 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    End2 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Start3 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    End3 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ComplexStart = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ComplexEnd = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    WorkingHoursId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHoursItems", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingHoursItems");
        }
    }
}
