using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class add_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegisterId",
                table: "Employers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Employers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nationalcode",
                table: "Employers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "Employers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "IsLegal",
                table: "Employers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "Employers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FName",
                table: "Employers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "Employees",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "EservicePassword",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EserviceUserName",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MclsPassword",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MclsUserName",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanaPassword",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanaUserName",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxOfficeUserName",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxOfficepassword",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployerWorkshop",
                columns: table => new
                {
                    EmployersListid = table.Column<long>(type: "bigint", nullable: false),
                    WorkshopsListid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerWorkshop", x => new { x.EmployersListid, x.WorkshopsListid });
                    table.ForeignKey(
                        name: "FK_EmployerWorkshop_Employers_EmployersListid",
                        column: x => x.EmployersListid,
                        principalTable: "Employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployerWorkshop_Workshops_WorkshopsListid",
                        column: x => x.WorkshopsListid,
                        principalTable: "Workshops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "LeftWork",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeftWorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartWorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkshopId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WorkshopName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeftWork", x => x.id);
                    table.ForeignKey(
                        name: "FK_LeftWork_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeftWork_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 336, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.InsertData(
                table: "File_States",
                columns: new[] { "id", "CreationDate", "FileTiming_Id", "State", "Title" },
                values: new object[] { 8L, new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3815), 1L, 8, "تاریخ ثبت دادخواست ثبت نشده است" });

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2825));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2834));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.CreateIndex(
                name: "IX_EmployerWorkshop_WorkshopsListid",
                table: "EmployerWorkshop",
                column: "WorkshopsListid");

            migrationBuilder.CreateIndex(
                name: "IX_LeftWork_EmployeeId",
                table: "LeftWork",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeftWork_WorkshopId",
                table: "LeftWork",
                column: "WorkshopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployerWorkshop");

            migrationBuilder.DropTable(
                name: "Leave");

            migrationBuilder.DropTable(
                name: "LeftWork");

            migrationBuilder.DeleteData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DropColumn(
                name: "EservicePassword",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EserviceUserName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MclsPassword",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MclsUserName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SanaPassword",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SanaUserName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TaxOfficeUserName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TaxOfficepassword",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterId",
                table: "Employers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Employers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nationalcode",
                table: "Employers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "Employers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsLegal",
                table: "Employers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "Employers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FName",
                table: "Employers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "Employees",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 386, DateTimeKind.Local).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(8765));
        }
    }
}
