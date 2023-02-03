using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class WorkshopEmployers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Employers_EmployerId",
                table: "Workshops");

            migrationBuilder.DropIndex(
                name: "IX_Workshops_EmployerId",
                table: "Workshops");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "Workshops");

            migrationBuilder.CreateTable(
                name: "WorkshopeEmployers",
                columns: table => new
                {
                    WorkshopId = table.Column<long>(type: "bigint", nullable: false),
                    EmployerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopeEmployers", x => new { x.WorkshopId, x.EmployerId });
                    table.ForeignKey(
                        name: "FK_WorkshopeEmployers_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopeEmployers_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopeEmployers_EmployerId",
                table: "WorkshopeEmployers",
                column: "EmployerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopeEmployers");

            migrationBuilder.AddColumn<long>(
                name: "EmployerId",
                table: "Workshops",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Workshops_EmployerId",
                table: "Workshops",
                column: "EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Employers_EmployerId",
                table: "Workshops",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
