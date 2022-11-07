using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class RelationContratWorkingHoursAndWorkigHoursItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkingHoursItems_WorkingHoursId",
                table: "WorkingHoursItems",
                column: "WorkingHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_ContractId",
                table: "WorkingHours",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Contracts_ContractId",
                table: "WorkingHours",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHoursItems_WorkingHours_WorkingHoursId",
                table: "WorkingHoursItems",
                column: "WorkingHoursId",
                principalTable: "WorkingHours",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Contracts_ContractId",
                table: "WorkingHours");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHoursItems_WorkingHours_WorkingHoursId",
                table: "WorkingHoursItems");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHoursItems_WorkingHoursId",
                table: "WorkingHoursItems");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_ContractId",
                table: "WorkingHours");
        }
    }
}
