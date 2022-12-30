using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class RelationWOrkshopLeftwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

          

            migrationBuilder.AddForeignKey(
                name: "FK_LeftWork_Employees_EmployeeId",
                table: "LeftWork",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeftWork_Workshops_WorkshopId",
                table: "LeftWork",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
      

       

            migrationBuilder.DropIndex(
                name: "IX_LeftWork_EmployeeId",
                table: "LeftWork");

            migrationBuilder.DropIndex(
                name: "IX_LeftWork_WorkshopId",
                table: "LeftWork");

           
        }
    }
}
