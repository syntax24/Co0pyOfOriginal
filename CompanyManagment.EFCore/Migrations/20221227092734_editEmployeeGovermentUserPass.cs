using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class editEmployeeGovermentUserPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
