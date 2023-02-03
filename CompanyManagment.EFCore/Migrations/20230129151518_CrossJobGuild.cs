using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class CrossJobGuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrossJobGuilds",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EconomicCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossJobGuilds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CrossJobs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SalaryRatioUnder = table.Column<double>(type: "float", nullable: false),
                    EquivalentRialUnder = table.Column<long>(type: "bigint", nullable: false),
                    SalaryRatioOver = table.Column<double>(type: "float", nullable: false),
                    EquivalentRialOver = table.Column<long>(type: "bigint", nullable: false),
                    CrossJobGuildId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossJobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_CrossJobs_CrossJobGuilds_CrossJobGuildId",
                        column: x => x.CrossJobGuildId,
                        principalTable: "CrossJobGuilds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CrossJobs_CrossJobGuildId",
                table: "CrossJobs",
                column: "CrossJobGuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrossJobs");

            migrationBuilder.DropTable(
                name: "CrossJobGuilds");

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

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3815));

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
    }
}
