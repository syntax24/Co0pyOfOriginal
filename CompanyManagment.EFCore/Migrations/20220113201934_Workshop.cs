using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class Workshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkshopName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InsuranceCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployerId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsActiveString = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TypeOfOwnership = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArchiveCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AgentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AgentPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeOfInsuranceSend = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeOfContract = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.id);
                    table.ForeignKey(
                        name: "FK_Workshops_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workshops_EmployerId",
                table: "Workshops",
                column: "EmployerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workshops");
        }
    }
}
