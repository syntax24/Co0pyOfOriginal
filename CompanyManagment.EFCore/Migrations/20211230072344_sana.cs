using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class sana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EservicePassword",
                table: "Employers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EserviceUserName",
                table: "Employers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MclsPassword",
                table: "Employers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MclsUserName",
                table: "Employers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanaPassword",
                table: "Employers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanaUserName",
                table: "Employers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxOfficeUserName",
                table: "Employers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxOfficepassword",
                table: "Employers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EservicePassword",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "EserviceUserName",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "MclsPassword",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "MclsUserName",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "SanaPassword",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "SanaUserName",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "TaxOfficeUserName",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "TaxOfficepassword",
                table: "Employers");
        }
    }
}
