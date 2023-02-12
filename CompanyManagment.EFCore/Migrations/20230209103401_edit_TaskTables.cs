using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class edit_TaskTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferralRecipient_Id",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskDate",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "DeadlineRegUserId",
                table: "TaskStatuses",
                newName: "DeadlineExtentionRegUserId");

            migrationBuilder.RenameColumn(
                name: "DeadlineRegDate",
                table: "TaskStatuses",
                newName: "DeadlineExtentionRegDate");

            migrationBuilder.RenameColumn(
                name: "DeadlineDate",
                table: "TaskStatuses",
                newName: "DeadlineExtentionDate");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeadlineExtentionRegUserId",
                table: "TaskStatuses",
                newName: "DeadlineRegUserId");

            migrationBuilder.RenameColumn(
                name: "DeadlineExtentionRegDate",
                table: "TaskStatuses",
                newName: "DeadlineRegDate");

            migrationBuilder.RenameColumn(
                name: "DeadlineExtentionDate",
                table: "TaskStatuses",
                newName: "DeadlineDate");

            migrationBuilder.AddColumn<long>(
                name: "ReferralRecipient_Id",
                table: "Tasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "TaskDate",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            
        }
    }
}
