using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class YearlySalarytitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YearlySalaryTitles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title5 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title6 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title7 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title8 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title9 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title10 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlySalaryTitles", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearlySalaryTitles");
        }
    }
}
