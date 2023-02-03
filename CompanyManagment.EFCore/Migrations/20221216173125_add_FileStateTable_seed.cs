using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class add_FileStateTable_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "File_States",
                columns: new[] { "id", "CreationDate", "FileTiming_Id", "State", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 12, 16, 21, 1, 24, 156, DateTimeKind.Local).AddTicks(1576), 1L, 1, "کلاسه پرونده ثبت نشده است" },
                    { 2L, new DateTime(2022, 12, 16, 21, 1, 24, 162, DateTimeKind.Local).AddTicks(6589), 1L, 2, "وکالت نامه پرونده ثبت نشده است" },
                    { 3L, new DateTime(2022, 12, 16, 21, 1, 24, 162, DateTimeKind.Local).AddTicks(6698), 2L, 3, "دعوتنامه ای برای جلسات دادگاه تشخیص صادر نشده است" },
                    { 4L, new DateTime(2022, 12, 16, 21, 1, 24, 162, DateTimeKind.Local).AddTicks(6715), 3L, 4, "دعوتنامه جدید یا دادنامه تشخیص صادر نشده است" },
                    { 5L, new DateTime(2022, 12, 16, 21, 1, 24, 162, DateTimeKind.Local).AddTicks(6724), 4L, 5, "اعتراض برای پرونده ثبت نشده است" },
                    { 6L, new DateTime(2022, 12, 16, 21, 1, 24, 162, DateTimeKind.Local).AddTicks(6735), 5L, 6, "دعوتنامه ای برای جلسات دادگاه تجدیدنظر صادر نشده است" },
                    { 7L, new DateTime(2022, 12, 16, 21, 1, 24, 162, DateTimeKind.Local).AddTicks(6744), 6L, 7, "دعوتنامه جدید یا دادنامه تجدیدنظر صادر نشده است" }
                });

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 1, 24, 168, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 1, 24, 168, DateTimeKind.Local).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 1, 24, 168, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 1, 24, 168, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 1, 24, 168, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 1, 24, 168, DateTimeKind.Local).AddTicks(8236));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 14, 8, 592, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 14, 8, 599, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 14, 8, 599, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 14, 8, 599, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 14, 8, 599, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 14, 8, 599, DateTimeKind.Local).AddTicks(2488));
        }
    }
}
