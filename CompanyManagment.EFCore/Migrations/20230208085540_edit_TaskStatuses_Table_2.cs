using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class edit_TaskStatuses_Table_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineExtention",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "Done",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "Impossibility",
                table: "TaskStatuses");

            migrationBuilder.RenameColumn(
                name: "ImpossibilityDate",
                table: "TaskStatuses",
                newName: "ReferralRegDate");

            migrationBuilder.RenameColumn(
                name: "DoneTime",
                table: "TaskStatuses",
                newName: "DoneRegDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineRegDate",
                table: "TaskStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ImpossibilityRegDate",
                table: "TaskStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "ReferralRegUserId",
                table: "TaskStatuses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<short>(
                name: "ReferralStatus",
                table: "TaskStatuses",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineRegDate",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "ImpossibilityRegDate",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "ReferralRegUserId",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "ReferralStatus",
                table: "TaskStatuses");

            migrationBuilder.RenameColumn(
                name: "ReferralRegDate",
                table: "TaskStatuses",
                newName: "ImpossibilityDate");

            migrationBuilder.RenameColumn(
                name: "DoneRegDate",
                table: "TaskStatuses",
                newName: "DoneTime");

            migrationBuilder.AddColumn<int>(
                name: "DeadlineExtention",
                table: "TaskStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Done",
                table: "TaskStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Impossibility",
                table: "TaskStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
