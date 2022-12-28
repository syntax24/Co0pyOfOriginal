using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class Leave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartLeave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndLeave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveHourses = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    WorkshopId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    PaidLeaveType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LeaveType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WorkshopName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leave");
        }
    }
}
