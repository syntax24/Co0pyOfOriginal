using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class WorkingHourAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftWork = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ContractNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NumberOfWorkingDays = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumberOfFriday = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TotalHoursesH = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TotalHoursesM = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    OverTimeWorkH = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    OverTimeWorkM = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    OverNightWorkH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OverNightWorkM = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    WeeklyWorkingTime = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingHours");
        }
    }
}
