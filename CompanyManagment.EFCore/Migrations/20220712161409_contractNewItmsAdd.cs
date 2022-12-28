using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class contractNewItmsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryAgg",
                table: "Contracts");

            migrationBuilder.AlterColumn<string>(
                name: "DayliWage",
                table: "Contracts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "AgreementSalary",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConsumableItems",
                table: "Contracts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HousingAllowance",
                table: "Contracts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkingHoursWeekly",
                table: "Contracts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreementSalary",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ConsumableItems",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "HousingAllowance",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "WorkingHoursWeekly",
                table: "Contracts");

            migrationBuilder.AlterColumn<double>(
                name: "DayliWage",
                table: "Contracts",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<double>(
                name: "SalaryAgg",
                table: "Contracts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
