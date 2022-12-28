using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class LegalAndPersonalToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsLegal",
                table: "PersonalContractingParties",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                table: "PersonalContractingParties",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "PersonalContractingParties",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegisterId",
                table: "PersonalContractingParties",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLegal",
                table: "PersonalContractingParties");

            migrationBuilder.DropColumn(
                name: "LegalName",
                table: "PersonalContractingParties");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "PersonalContractingParties");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "PersonalContractingParties");
        }
    }
}
