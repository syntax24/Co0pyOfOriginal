using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class EmployeeAndChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfIssue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsActiveString = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MilitaryService = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LevelOfEducation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BankCardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankBranch = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InsuranceCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InsuranceHistoryByYear = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InsuranceHistoryByMonth = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NumberOfChildren = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeChildren",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentNationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeChildren", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmployeeChildren_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeChildren_EmployeeId",
                table: "EmployeeChildren",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeChildren");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
