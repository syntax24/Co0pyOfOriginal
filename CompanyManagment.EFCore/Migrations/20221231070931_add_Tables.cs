using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class add_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      
 

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 336, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.InsertData(
                table: "File_States",
                columns: new[] { "id", "CreationDate", "FileTiming_Id", "State", "Title" },
                values: new object[] { 8L, new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3815), 1L, 8, "تاریخ ثبت دادخواست ثبت نشده است" });

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2825));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2834));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2846));

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DeleteData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L);

           

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 386, DateTimeKind.Local).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 391, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 18, 51, 1, 394, DateTimeKind.Local).AddTicks(8765));
        }
    }
}
