using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class edit_TaskTitles_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeadlineExnsion",
                table: "TaskStatuses",
                newName: "DeadlineExtention");

            migrationBuilder.AddColumn<short>(
                name: "DeadlineExtentionStatus",
                table: "TaskStatuses",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "DoneStatus",
                table: "TaskStatuses",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "ImpossibilityStatus",
                table: "TaskStatuses",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 766, DateTimeKind.Local).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 771, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 771, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 771, DateTimeKind.Local).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 771, DateTimeKind.Local).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 771, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 771, DateTimeKind.Local).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 771, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 775, DateTimeKind.Local).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 775, DateTimeKind.Local).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 775, DateTimeKind.Local).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 775, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 775, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 7, 19, 45, 29, 775, DateTimeKind.Local).AddTicks(3217));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineExtentionStatus",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "DoneStatus",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "ImpossibilityStatus",
                table: "TaskStatuses");

            migrationBuilder.RenameColumn(
                name: "DeadlineExtention",
                table: "TaskStatuses",
                newName: "DeadlineExnsion");

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 978, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(6272));
        }
    }
}
