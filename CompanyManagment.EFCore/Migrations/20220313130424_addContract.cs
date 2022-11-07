using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class addContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelCode = table.Column<long>(type: "bigint", nullable: false),
                    ContractNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EmployerId = table.Column<long>(type: "bigint", nullable: false),
                    WorkshopIds = table.Column<long>(type: "bigint", nullable: false),
                    YearlySalaryId = table.Column<long>(type: "bigint", nullable: false),
                    ContarctStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayliWage = table.Column<double>(type: "float", nullable: false),
                    IsActiveString = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ArchiveCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contracts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_YearlySalariess_YearlySalaryId",
                        column: x => x.YearlySalaryId,
                        principalTable: "YearlySalariess",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployerId",
                table: "Contracts",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_YearlySalaryId",
                table: "Contracts",
                column: "YearlySalaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
