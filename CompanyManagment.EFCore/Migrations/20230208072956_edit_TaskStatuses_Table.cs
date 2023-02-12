using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class edit_TaskStatuses_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeadlineRegUserId",
                table: "TaskStatuses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DoneRegUserId",
                table: "TaskStatuses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ImpossibilityRegUserId",
                table: "TaskStatuses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineRegUserId",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "DoneRegUserId",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "ImpossibilityRegUserId",
                table: "TaskStatuses");
        }
    }
}
