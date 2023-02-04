using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class AddParentRowIdToCrossJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentRowId",
                table: "CrossJobs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 793, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 801, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 801, DateTimeKind.Local).AddTicks(846));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 801, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 801, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 801, DateTimeKind.Local).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 801, DateTimeKind.Local).AddTicks(947));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 801, DateTimeKind.Local).AddTicks(841));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 803, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 803, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 803, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 803, DateTimeKind.Local).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 803, DateTimeKind.Local).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 2, 10, 44, 8, 803, DateTimeKind.Local).AddTicks(8336));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentRowId",
                table: "CrossJobs");

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 168, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(9448));
        }
    }
}
